param(
    [string]$MigrationName = "Init",
    [string]$Module = "Expenses"
)

dotnet ef migrations add $MigrationName `
  --project ../src/PiggyBank.$Module `
  --startup-project ../src/PiggyBank.Web `
  --output-dir Persistence/Migrations