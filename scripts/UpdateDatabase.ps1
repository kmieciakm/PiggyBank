param(
    [string]$Module = "Expenses"
)

dotnet ef database update `
  --startup-project ../src/PiggyBank/PiggyBank.Web