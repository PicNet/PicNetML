del *.nupkg
msbuild.exe Ml2\Ml2.csproj /verbosity:minimal /p:DocumentationFile=Ml2.xml
nuget.exe pack Ml2\Ml2.csproj -IncludeReferencedProjects
nuget.exe push PicNetML.*.nupkg
