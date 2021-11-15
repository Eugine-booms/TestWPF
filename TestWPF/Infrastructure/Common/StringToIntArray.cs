using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace TestWPFApp.Infrastructure.Common
{
    /// <summary>
    /// 
    /// </summary>
    [MarkupExtensionReturnType(typeof(int[]))]
    internal class StringToIntArray : MarkupExtension
    {
        [ConstructorArgument("Str")]
        public string Str { get; set; }
        [ConstructorArgument("Separator")]
        public Char Separator { get; set; } = ';';

        public StringToIntArray() { }
        public StringToIntArray(string str)
        {
            Str = str ?? throw new ArgumentNullException(nameof(str));
        }

        public StringToIntArray(string str, char sep) : this(str)
        {
            Separator = sep;
        }


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var result = Str
                    .Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
                    .DefaultIfEmpty()
                    .Select(int.Parse)
                    .ToArray();
            return result;
        }
    }
}
