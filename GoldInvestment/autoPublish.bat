
cd D:\sources\CraftingDesignUsingTDD\GoldInvestment

dotnet clean 

dotnet build

dotnet test

dotnet publish -o out

cd out

robocopy . D:\publish
dotnet GoldInvestment.Api.dll