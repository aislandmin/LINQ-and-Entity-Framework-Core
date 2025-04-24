// See https://aka.ms/new-console-template for more information
using Q1Lab4;

Console.WriteLine("Question 01 - Lab 04");

//Got countries all located in South America
List<Country> countries = Country.GetCountries();

// Invokes methods
Question1_1();
Question1_2();
Question1_3();
Question1_4();
Question1_5();
Question1_6();

// 1.1 List the names of the countries in alphabetical order [0.5 mark]
void Question1_1()
{
    //option1: Using Query syntax
    //var sortedCountryNames = from c in countries
    //                         orderby c.Name
    //                         select c.Name;

    //option2: using Method Syntax
    var sortedCountryNames = countries.OrderBy(c => c.Name).Select(c => c.Name);

    Console.WriteLine("1.1 List the names of the countries in alphabetical order");
    foreach (var name in sortedCountryNames)
    {
        Console.WriteLine($"{name}");
    }
}

// 1.2 List the names of the countries in descending order of number of resources [0.5 mark]
void Question1_2()
{
    //option1: Using Query syntax
    //var sortedCountrybyResources = from c in countries
    //                               orderby c.Resources.Count descending
    //                               select new { c.Name, ResourceCount = c.Resources.Count };

    //option2: using Method Syntax
    var sortedCountrybyResources 
        = countries.OrderByDescending(c => c.Resources.Count).Select(c => new { c.Name, ResourceCount = c.Resources.Count });

    Console.WriteLine("\n1.2 List the names of the countries in descending order of number of resources");
    foreach (var country in sortedCountrybyResources)
    {
        Console.WriteLine("{0,-15}({1,2}  Recouses)", country.Name, country.ResourceCount);
    }
}

// 1.3 List the names of the countries that shares a border with Argentina [0.5 mark]
void Question1_3()
{
    //option1: Using Query syntax
    var countriesBorderWithArgentina = from c in countries
                                       where c.Borders.Contains("Argentina")
                                       select c.Name;

    //option2: using Method Syntax
    //var countriesBorderWithArgentina 
    //    = countries.Where(c => c.Borders.Contains("Argentina")).Select(c => c.Name);

    Console.WriteLine("\n1.3 List the names of the countries that shares a border with Argentina");
    foreach (var name in countriesBorderWithArgentina)
    {
        Console.WriteLine($"{name}");
    }
}

// 1.4 List the names of the countries that has more than 10,000,000 population [0.5 mark]
void Question1_4()
{
    //option1: Using Query syntax
    //var countriesByPopulation = from c in countries
    //                            where c.Population > 10000000
    //                            select new { c.Name, c.Population };
    //option2: using Method Syntax
    var countriesByPopulation
        = countries.Where(c => c.Population > 10000000).Select(c => new { c.Name, c.Population});

    Console.WriteLine("\n1.4 List the names of the countries that has more than 10,000,000 population");
    foreach (var country in countriesByPopulation)
    {
        Console.WriteLine("{0,-15}({1,9}  Population)", country.Name, country.Population);
    }
}

// 1.5 List the country with highest population [1 mark]
void Question1_5()
{
    //option1: Using Query syntax
    //var countryWithHighestPopulation = (from c in countries
    //                                    orderby c.Population descending
    //                                    select c).First();

    //option2: using Method Syntax
    var countryWithHighestPopulation = countries.OrderByDescending(c => c.Population).First();

    Console.WriteLine("\n1.5 List the country with highest population");
    Console.WriteLine("{0,-15}({1,9}  Population)", 
        countryWithHighestPopulation.Name, countryWithHighestPopulation.Population);
}

// 1.6 List all the religion in south America in dictionary order [1 mark]
void Question1_6()
{
    //option1: using Query Syntax
    //var religions = from c in countries
    //                from r in c.Religions
    //                group r by r into g
    //                orderby g.Key
    //                select g.Key;

    //options2: using Method Syntax
    var religions = countries.SelectMany(c => c.Religions).Distinct().OrderBy(r => r);

    Console.WriteLine("\n1.6 List all the religion in south America in dictionary order");
    foreach (var religion in religions)
    {
        Console.WriteLine($"{religion}");
    }

}

// Prevent console from closing immediately
Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();
