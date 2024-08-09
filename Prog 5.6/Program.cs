class Program
{
    static void Main(string[] args)
    {
        (string name, string surname, int age, bool havePet, int petCount, string[] petNames, int colorCount, string[] colors) user;
        user.name = GetStringValue("Введите имя");
        user.surname = GetStringValue("Введите фамилию");
        user.age = GetIntValue("Введите возраст", 1, 100);
        user.havePet = GetBoolValue("Есть ли у вас питомец? (да/нет)");
        if (user.havePet)
        {
            user.petCount = GetIntValue("Введите количество питомцев", 1, int.MaxValue);
            user.petNames = GetPetNames(user.petCount);
        }
        else
        {
            user.petCount = 0;
            user.petNames = new string[0];
        }
        user.colorCount = GetIntValue("Введите количество любимых цветов", 1, int.MaxValue);
        user.colors = GetFavoriteColors(user.colorCount);
        ShowUserInfo(user);
    }
    static string GetStringValue(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }
    static int GetIntValue(string message, int minValue, int maxValue)
    {
        int value;
        bool isCorrect;
        do
        {
            Console.WriteLine(message);
            isCorrect = int.TryParse(Console.ReadLine(), out value) && value >= minValue && value <= maxValue;
            if (!isCorrect)
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
        } while (!isCorrect);
        return value;
    }
    static bool GetBoolValue(string message)
    {
        string value;
        bool isCorrect;
        do
        {
            Console.WriteLine(message);
            value = Console.ReadLine().ToLower();
            isCorrect = value == "да" || value == "нет";
            if (!isCorrect)
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
        } while (!isCorrect);
        return value == "да";
    }
    static string[] GetPetNames(int petCount)
    {
        string[] petNames = new string[petCount];
        for (int i = 0; i < petCount; i++)
        {
            petNames[i] = GetStringValue($"Введите кличку питомца {i + 1}");
        }
        return petNames;
    }
    static string[] GetFavoriteColors(int colorCount)
    {
        string[] colors = new string[colorCount];
        for (int i = 0; i < colorCount; i++)
        {
            colors[i] = GetStringValue($"Введите любимый цвет {i + 1}");
        }
        return colors;
    }
    static void ShowUserInfo((string name, string surname, int age, bool havePet, int petCount, string[] petNames, int colorCount, string[] colors) user)
    {
        Console.WriteLine($"Имя: {user.name}");
        Console.WriteLine($"Фамилия: {user.surname}");
        Console.WriteLine($"Возраст: {user.age}");
        Console.WriteLine($"Наличие питомца: {user.havePet}");
        if (user.havePet)
        {
            Console.WriteLine($"Количество питомцев: {user.petCount}");
            Console.WriteLine("Клички питомцев:");
            foreach (string petName in user.petNames)
            {
                Console.WriteLine(petName);
            }
        }
        Console.WriteLine($"Количество любимых цветов: {user.colorCount}");
        Console.WriteLine("Любимые цвета:");
        foreach (string color in user.colors)
        {
            Console.WriteLine(color);
        }
    }
}


