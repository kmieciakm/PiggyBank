param(
    [string]$MigrationName = "Init",
    [string]$Module = "Expenses"
)

dotnet ef migrations add $MigrationName `
  --project ../src/PiggyBank/PiggyBank.$Module `
  --startup-project ../src/PiggyBank/PiggyBank.Web `
  --output-dir Persistence/Migrations