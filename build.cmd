rmdir %userprofile%\.nuget\packages\dotnet-flubu /S /Q
rmdir %userprofile%\.nuget\packages\flubu.core /S /Q
rmdir %userprofile%\.nuget\packages\.tools\dotnet-flubu /S /Q

cd flubu.core
dotnet restore
dotnet pack
cd ..

cd dotnet-flubu
dotnet restore
dotnet pack

cd ..
mkdir flubu.console\nuget
copy flubu.core\bin\Debug\*.nupkg test\flubu.console\nuget /Y
copy dotnet-flubu\bin\Debug\*.nupkg test\flubu.console\nuget /Y

cd test\flubu.console
dotnet restore -f nuget
cd ..
cd ..

cd flubu.tests
dotnet test
cd..