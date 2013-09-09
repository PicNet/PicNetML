del *.nupkg
msbuild.exe PicNetML\PicNetML.csproj /verbosity:minimal /p:DocumentationFile=PicNetML.xml
nuget.exe pack PicNetML\PicNetML.csproj -IncludeReferencedProjects
nuget.exe push PicNetML.*.nupkg
