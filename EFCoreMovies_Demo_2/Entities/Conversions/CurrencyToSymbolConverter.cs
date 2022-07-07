using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreMovies_Demo_2.Entities.Conversions;

public class CurrencyToSymbolConverter : ValueConverter<Currency, string>
{
    public CurrencyToSymbolConverter() 
        : base(value => MapCurrencyToString(value), value => MapStringToCurrency(value))
    {

    }

    private static string MapCurrencyToString(Currency value)
    {
        return value switch
        {
            Currency.DominicanPeso => "RD$",
            Currency.USDollar => "$",
            Currency.Euro => "€",
            _ => ""
        };
    }

    private static Currency MapStringToCurrency(string value)
    {
        return value switch
        {
            "RD$" => Currency.DominicanPeso,
            "$" => Currency.USDollar,
            "€" => Currency.Euro,
            _ => Currency.Unknown
        };
    }
}