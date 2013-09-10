using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using ICSharpCode.SharpZipLib.Zip;
using NUnit.Framework;
using PicNetML.Tasks.Generator;

namespace PicNetML.Tasks.WekaUpdater {
  [TestFixture, Ignore("Run Manually")] public class Updater {
    [SetUp, TearDown] public void CleanUpWorkingFiles() {
      var all = Directory.GetFiles(".", "*.zip").Concat(Directory.GetFiles(".", "*.jar")).ToArray();
      Array.ForEach(all, File.Delete);
      if (Directory.Exists("weka")) {
        var wekafiles = Directory.GetFiles("weka").ToArray();
        Array.ForEach(wekafiles , File.Delete);
        Directory.Delete("weka");
      }
    }

    [Test] public void UpdateWekaLibs() {
      Console.WriteLine("Downloading the latest dev weka.zip");
      DownloadWekaLib();

      Console.WriteLine("Unzipping the weka.jar");
      UnzipWekaJar();

      Console.WriteLine("Copying weka.jar to lib directory");
      CopyWekaJarToLibDir();

      Console.WriteLine("Running IKVM on weka.jar");
      RunBuilWekaDll();

      Console.WriteLine("Running the code generator using the new weka.dll");
      RunCodeGenerator();
    }    

    private static void DownloadWekaLib() {
      Assert.IsFalse(File.Exists("developer-branch.zip"));
      using (var Client = new WebClient()) {
        Client.DownloadFile("http://www.cs.waikato.ac.nz/ml/weka/snapshots/developer-branch.zip", "developer-branch.zip");
      }
    }

    private void UnzipWekaJar() {
      Assert.IsTrue(File.Exists("developer-branch.zip"));
      Assert.IsFalse(File.Exists(@"weka\weka.jar"));

      var fz = new FastZip();
      fz.ExtractZip("developer-branch.zip", ".", "weka.jar");
    }

    private static void CopyWekaJarToLibDir() {
      Assert.IsTrue(File.Exists(@"weka\weka.jar"));
      var target = @"..\..\..\lib\weka\weka.jar";
      if (File.Exists(target)) { File.Delete(target); }

      File.Move(@"weka\weka.jar", target);
    }

    private void RunBuilWekaDll() {
      var proc = new Process {
        StartInfo = new ProcessStartInfo {          
          UseShellExecute = false,
          RedirectStandardOutput = true,
          RedirectStandardError = true,
          CreateNoWindow = true,          
          WorkingDirectory = @"..\..\..",
          FileName = new FileInfo(@"..\...\..\build_weka_dlls.bat").FullName
        }
      };
      proc.Start();
      while (!proc.StandardOutput.EndOfStream) {
        Console.WriteLine(proc.StandardOutput.ReadLine());
      }
      while (!proc.StandardError.EndOfStream) {
        Console.WriteLine(proc.StandardError.ReadLine());
      }
      var code = proc.ExitCode;
      Assert.AreEqual(0, code);
    }

    private void RunCodeGenerator() {
      new CodeGenerator().GenerateAll();
    }
  }
}