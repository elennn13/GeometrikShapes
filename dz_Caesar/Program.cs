using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//001.Напишите консольное приложение,
//позволяющее сохранить введённый пользователем
//текст в файл, предварительно зашифровав его шифром
//Цезаря (описание метода широко доступно в интернет,
//суть в циклическом сдвиге используемого алфавита).
//Необходимо предусмотреть интерфейс для общения
//с пользователем: меню, демонстрацию полученного
//шифра и отчёт о благополучной записи в файл с именем
//файла. Будет отдельным плюсом использование аргументов
//командной строки для указания файла(-ов), который(-ые)
//нужно зашифровать.
//002.* Усовершенствуйте описанное выше приложение,
//чтобы оно позволяло  расшифровывать текстовые документы,
//ранее зашифрованные вашим приложением.
//003.* Добавьте произвольную длину сдвига, используемого
//для шифрования и расшифровки.
//004.* Добавьте для шифорования/расшифровки возможность
//добавления списка сдвигов. Этот список должен добавляться
//пользователем при использовании программы, как аргумент
//коммандной строки. Возможно использование определённого
//ключа.
//       Алгоритм решения
//Создаем консольное приложение с меню:
//Шифрование текста
//Дешифрование текста
//Выход
//Реализуем шифр Цезаря:
//Для каждого символа в тексте выполняем сдвиг в алфавите
//Учитываем русские и английские буквы
//Сохраняем регистр символов
//Не изменяем символы, не являющиеся буквами
//Работа с файлами:
//Чтение текста из файла
//Запись зашифрованного/дешифрованного текста в файл
//Поддержка аргументов командной строки
//Доп функции:
//Произвольная длина сдвига
//Список сдвигов для каждого символа
//Ключ для шифрования/дешифрования*/

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Обработка аргументов командной строки
            if (args.Length > 0)
            {
                ProcessCommandLineArgs(args);
                return;
            }


            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Зашифровать текст");
                Console.WriteLine("2. Расшифровать текст");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine(); // читаем выбор пользователя

                switch (choice) // в зависимости от выбора пользователя
                {
                    case "1":
                        EncryptText(); // если 1 Вызов функции шифрования
                        break;
                    case "2":
                        DecryptText(); // если 2 Вызов функции дешифрования
                        break;
                    case "3":
                        return; // если 3 Выход из программы
                    default:
                        Console.WriteLine("Неверный выбор!"); // если что то другое, то ошибка 
                        break;
                }
            }
        }

        // Обработка аргументов командной строки
        static void ProcessCommandLineArgs(string[] args)
        {
            try
            {
                if (args.Length < 3) // Проверка количества аргументов, если меньше 3 то показваем подсказку
                {
                    Console.WriteLine("Использование:");
                    Console.WriteLine("Для шифрования: program.exe -e файл сдвиг [ключ]");
                    Console.WriteLine("Для дешифрования: program.exe -d файл сдвиг [ключ]");
                    return;
                }

                string mode = args[0];     // получаем Режим (-e или -d)
                string filePath = args[1]; // получаем Путь к файлу
                string shiftArg = args[2]; // получаем Сдвиг или ключ
                string key = args.Length > 3 ? args[3] : null;  // Дополнительный ключ

                if (!File.Exists(filePath))   // Проверка существования файла
                {
                    Console.WriteLine("Файл не найден!");
                    return;
                }
                // Читаем весь текст из файла
                string text = File.ReadAllText(filePath);
                string result;

                // если режим шифрования
                if (mode == "-e")
                {
                    if (key != null)
                    {
                        result = EncryptWithKey(text, key); // Шифрование с ключом
                    }
                    else if (int.TryParse(shiftArg, out int shift))
                    {
                        result = CaesarEncrypt(text, shift);  // Шифрование с числовым сдвигом
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат сдвига!");
                        return;
                    }
                    // Сохранение зашифрованного текста
                    File.WriteAllText(filePath + ".encrypted", result);
                    Console.WriteLine($"Текст зашифрован и сохранен в {filePath}.encrypted");
                }
                // Обработка режима дешифрования (аналогично шифрованию)
                else if (mode == "-d")
                {
                    if (key != null)
                    {
                        result = DecryptWithKey(text, key);
                    }
                    else if (int.TryParse(shiftArg, out int shift))
                    {
                        result = CaesarDecrypt(text, shift);
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат сдвига!");
                        return;
                    }
                    File.WriteAllText(filePath + ".decrypted", result);
                    Console.WriteLine($"Текст расшифрован и сохранен в {filePath}.decrypted");
                }
                else
                {
                    Console.WriteLine("Неверный режим! Используйте -e или -d");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Шифрование текста через меню
        static void EncryptText()
        {
            try
            {
                Console.WriteLine("\nШифрование текста:");
                Console.Write("Введите текст: ");
                // Читаем текст для шифрования
                string text = Console.ReadLine();

                Console.WriteLine("Выберите метод:");
                Console.WriteLine("1. Сдвиг (число)");
                Console.WriteLine("2. Ключевое слово");
                Console.Write("Ваш выбор: ");
                // Читаем выбранный метод
                string method = Console.ReadLine();

                string encryptedText; // Сюда сохраним зашифрованный текст
                string fileName;      // Имя файла для сохранения


                if (method == "1")
                {
                    Console.Write("Введите сдвиг: ");
                    // Пробуем прочитать число (сдвиг)
                    if (!int.TryParse(Console.ReadLine(), out int shift))
                    {
                        Console.WriteLine("Неверный формат сдвига!");
                        return;
                    }
                    // Шифруем с заданным сдвигом
                    encryptedText = CaesarEncrypt(text, shift);
                    // Формируем имя файла
                    fileName = $"encrypted_shift{shift}.txt";
                }
                else if (method == "2")
                {
                    Console.Write("Введите ключевое слово: ");
                    // Читаем ключ
                    string key = Console.ReadLine();
                    // Шифруем с ключом
                    encryptedText = EncryptWithKey(text, key);
                    fileName = $"encrypted_key{key}.txt";
                }
                else
                {
                    Console.WriteLine("Неверный выбор метода!");
                    return;
                }
                // Сохраняем зашифрованный текст в файл
                File.WriteAllText(fileName, encryptedText);
                // Показываем результат
                Console.WriteLine("\nЗашифрованный текст:");
                Console.WriteLine(encryptedText);
                Console.WriteLine($"\nТекст сохранен в файл: {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Дешифрование текста через меню
        static void DecryptText()
        {
            try
            {
                Console.WriteLine("\nДешифрование текста:");
                Console.Write("Введите текст: ");
                string text = Console.ReadLine();

                Console.WriteLine("Выберите метод:");
                Console.WriteLine("1. Сдвиг (число)");
                Console.WriteLine("2. Ключевое слово");
                Console.Write("Ваш выбор: ");
                string method = Console.ReadLine();

                string decryptedText;
                string fileName;

                if (method == "1")
                {
                    Console.Write("Введите сдвиг: ");
                    if (!int.TryParse(Console.ReadLine(), out int shift))
                    {
                        Console.WriteLine("Неверный формат сдвига!");
                        return;
                    }
                    decryptedText = CaesarDecrypt(text, shift);
                    fileName = $"decrypted_shift{shift}.txt";
                }
                else if (method == "2")
                {
                    Console.Write("Введите ключевое слово: ");
                    string key = Console.ReadLine();
                    decryptedText = DecryptWithKey(text, key);
                    fileName = $"decrypted_key{key}.txt";
                }
                else
                {
                    Console.WriteLine("Неверный выбор метода!");
                    return;
                }

                File.WriteAllText(fileName, decryptedText);
                Console.WriteLine("\nРасшифрованный текст:");
                Console.WriteLine(decryptedText);
                Console.WriteLine($"\nТекст сохранен в файл: {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Шифрование методом Цезаря с заданным сдвигом
        static string CaesarEncrypt(string text, int shift)
        {
            // Создаем "строитель" для результата
            StringBuilder result = new StringBuilder();
            // Перебираем каждый символ в тексте
            foreach (char c in text)
            {
                if (char.IsLetter(c)) // Если это буква
                {
                    // Определяем смещение для разных алфавито (A для больших, a для маленьких)
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    if (IsRussianLetter(c))
                    {
                        offset = char.IsUpper(c) ? 'А' : 'а';
                        // Формула шифрования для русского алфавита (32 буквы)
                        result.Append((char)(((c + shift - offset) % 32 + 32) % 32 + offset));
                    }
                    else
                    {
                        // Формула шифрования для английского алфавита (26 букв)
                        result.Append((char)(((c + shift - offset) % 26 + 26) % 26 + offset));
                    }
                }
                else
                {
                    // Не буквы оставляем без изменений
                    result.Append(c);
                }
            }
            // Возвращаем зашифрованный текст
            return result.ToString();
        }

        // Дешифрование методом Цезаря с заданным сдвигом
        static string CaesarDecrypt(string text, int shift)
        {
            return CaesarEncrypt(text, -shift); // Дешифровка - обратный сдвиг
        }

        // Проверка, является ли символ русской буквой
        static bool IsRussianLetter(char c)
        {
            return (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё';
        }

        // Шифрование с использованием ключевого слова
        static string EncryptWithKey(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0; // Индекс текущего символа ключа

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    // Вычисляем сдвиг на основе символа ключа
                    int shift = char.ToLower(key[keyIndex % key.Length]) - 'a' + 1;
                    // Шифруем текущий символ
                    result.Append(CaesarEncrypt(c.ToString(), shift));
                    keyIndex++;
                }
                else
                {
                    result.Append(c); // Не буквы оставляем как есть
                }
            }

            return result.ToString();
        }

        // Дешифрование с использованием ключевого слова
        static string DecryptWithKey(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    int shift = char.ToLower(key[keyIndex % key.Length]) - 'a' + 1;
                    result.Append(CaesarDecrypt(c.ToString(), shift));
                    keyIndex++;
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}