using System;

namespace Tumakov
{
    enum BankTypes
    {
        Current,
        Saving
    }
    class Bank
    {
        private static uint accountNumberSeed = 0;
        private uint _accountNumber;
        public uint accountNumber
        {
            get => _accountNumber;
        }
        private decimal _accountBalance;
        public decimal accountBalance { 
            get => _accountBalance;
        }
        private BankTypes _accountBankType;
        public BankTypes accountBankType
        {
            get => _accountBankType;
            set => _accountBankType = value; 
        }
        public Bank(decimal accountBalance, BankTypes accountBankType)
        {
            _accountNumber = GenerateAccountNumber();
            _accountBalance = accountBalance;
            _accountBankType = accountBankType;
        }
        public void UpdateAccountBankType(BankTypes accountBankType)
        {
            this.accountBankType = accountBankType;
        }
        private uint GenerateAccountNumber()
        {
            accountNumberSeed++;
            return accountNumberSeed;
        }
        public void ReplenishAccountBalance(decimal accountBalance)
        {
            if (accountBalance >= 0)
                _accountBalance += accountBalance;
            else
                Console.WriteLine("Введено отрицательное значение!");
        }
        public void WithdrawAccountBalance(decimal accountBalance)
        {
            if (accountBalance <= this.accountBalance && accountBalance >= 0)
                _accountBalance -= accountBalance;
            else
                Console.WriteLine("Недостаточно денег на счете! Либо введено отрицательное значение!");
        }
        public void TransferMoneyToAnotherAccount(Bank secondAccount, uint sumOfTransfer)
        {
            if (sumOfTransfer > 0)
            {
                if (_accountBalance > sumOfTransfer)
                {
                    _accountBalance -= sumOfTransfer;
                    secondAccount._accountBalance += sumOfTransfer;
                    Console.WriteLine("Деньги успешно переведены!");
                }
                else
                    Console.WriteLine("На счете недостаточно средств!");
            }
            else
                Console.WriteLine("Введите положительное значение!!!");
        }
    }
}