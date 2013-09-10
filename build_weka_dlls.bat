ECHO OFF

REM DOWNLOAD WEKA FROM: http://www.cs.waikato.ac.nz/ml/weka/snapshots/developer-branch.zip
REM DOWNLOAD WEKA PACKAGES FROM: http://sourceforge.net/projects/weka/files/weka-packages/

%cd:~0,3%\dev\tools\ikvm\bin\ikvmc -debug -target:library^
 -classloader:ikvm.runtime.ClassPathAssemblyClassLoader^
 lib\weka\weka.jar lib\weka\packages\*.jar -out:lib\weka.dll
