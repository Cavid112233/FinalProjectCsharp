using C__Final.Enums;
namespace C__Final.Helper
{
   public static class EnumHelper
    {
      
        public static T ReadEnum<T>(string caption)
            where T : Enum
        {

            foreach (var item in Enum.GetValues(typeof(T)))
            {

                Type utype = Enum.GetUnderlyingType(typeof(T));

                var id = Convert.ChangeType(item, utype);

                Console.WriteLine($"{id.ToString().PadLeft(2, '0')}.{item}");
            }

            string income;
        l1:
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(caption);
            Console.ForegroundColor = oldColor;

            income = Console.ReadLine();

            if (!Enum.TryParse(typeof(T), income, out object value) || (!Enum.IsDefined(typeof(T), value)))
            {
                goto l1;
            }

            return (T)value;
        }
    }
}
