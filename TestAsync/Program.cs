Repository repo = new Repository();
IAsyncEnumerable<string> data = repo.GetDataAsync();
await foreach (var name in data)
{
    Console.WriteLine(name);
}

await foreach (var number in GetNumbersAsync())
{
    Console.WriteLine(number);
}

await PrintAsync();   // вызов асинхронного метода
Console.WriteLine("Некоторые действия в методе Main");



// определение асинхронного метода
async Task PrintAsync()
{
    await Task.Delay(3000);
    Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
    await Task.Run(() => Print());                // выполняется асинхронно
    Console.WriteLine("Конец метода PrintAsync");
}

void Print()
{
    Thread.Sleep(3000);     // имитация продолжительной работы
    Console.WriteLine("Hello METANIT.COM");
}

async IAsyncEnumerable<int> GetNumbersAsync()
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(100);
        yield return i;
    }
}

class Repository
{
    string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };
    public async IAsyncEnumerable<string> GetDataAsync()
    {
        for (int i = 0; i < data.Length; i++)
        {
            Console.WriteLine($"Получаем {i + 1} элемент");
            Task.Delay(1500);
            yield return data[i];
        }
    }
}

