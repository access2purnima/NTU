using System;

class Program
{
    static void Main()
    {
        decimal AnnualIncome
               ,PaybleTax = 0 
               ,DefaultTaxallowance = 11500
               ,TaxableIncome = 0;

        //Enter the Taxable income rates
        decimal Basic_income_band = 33500
               ,Higher_income_band = 150000;              

        //Enter the tax rate band
        decimal Basic_Taxrate = 0.2m
               ,High_Taxrate = 0.4m
               ,Additional_Taxrate = 0.45m;

        Console.Write("Please enter your Annual income:£");
        AnnualIncome = decimal.Parse(Console.ReadLine());

        //Tax allowance goes down by £1 for every £2 if Annual Income is > 100000
        if (AnnualIncome <= DefaultTaxallowance)
        {
            TaxableIncome = 0.00m;
        }
        else if (AnnualIncome < 100000)
        {
            TaxableIncome = AnnualIncome - DefaultTaxallowance;            
        }
        else if (AnnualIncome > (100000 + (DefaultTaxallowance * 2)))
        {            
            TaxableIncome = AnnualIncome;
        }
        else
        {
            TaxableIncome = AnnualIncome - (DefaultTaxallowance - ((AnnualIncome - 100000)/2));
        }        

        //Calculate personal tax based on the above band
        if (AnnualIncome > DefaultTaxallowance)
        {
            PaybleTax = 0.00m;
        }
        else if (AnnualIncome <= Basic_income_band)
        {
            PaybleTax = TaxableIncome * Basic_Taxrate;  //Basic rate
        }
        else if (AnnualIncome <= Higher_income_band)
        {
            PaybleTax =  (Basic_income_band * Basic_Taxrate) 
                       + ((TaxableIncome - Basic_income_band) * High_Taxrate);  //High rate
        }
        else if(AnnualIncome > Higher_income_band)
        {
            //Additional rate
            PaybleTax = (Basic_income_band * Basic_Taxrate) 
                       + ((Higher_income_band - Basic_income_band) * High_Taxrate)
                       + ((TaxableIncome - Higher_income_band) * Additional_Taxrate);
        }       

        Console.WriteLine("Your taxable income is £" + TaxableIncome);
        Console.WriteLine("Your payble income tax is £" + PaybleTax);

        Console.WriteLine("Press any key for exit");
        Console.ReadKey();
    }
}

