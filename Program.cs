using System.IO;

Menu();

static void Menu()
{
    Console.Clear();

    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Abrir arquivo");
    Console.WriteLine("2 - Editar arquivo");
    Console.WriteLine("0 - Sair");
    short option = short.Parse(Console.ReadLine());
    switch (option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: OpenText(); break;
        case 2: EditText(); break;
        default: Menu(); break;
    }
}

static void OpenText()
{
    Console.Clear();
    Console.WriteLine("Qual caminho do arquivo");
    string path = Console.ReadLine();

    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }

    Console.WriteLine("");
    Console.ReadLine();

    Menu();
}

static void EditText()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo");
    Console.WriteLine("-----------------------------");
    //todo caracter abaixo dessa linha quero armazenar

    string text = "";
    //Enquanto o usr não digitar ESC, tudo que ele digitar etará
    // salvo na varável text.
    //Ou seja, enquanto o usr não apertar o ESC ele não vai sair
    // desse loop de repetição

    //Como o while é executado verifica a condição antes de começar a executar
    //utilizamos o DO para inicializarmos o loop
    //faça algo até que...
    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);
    Save(text);
}

static void Save(String text)
{
    Console.Clear();
    Console.WriteLine("coloque o caminho para salvar o arquivo");
    var path = Console.ReadLine();

    //sempre lembrar que toda vez que abrir um arquivo, fechar ele
    //td objeto que for passado para o using, é aberto e fechado automáticamente
    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }

    Console.WriteLine($"Arquivo salvo em  {path} com sucesso!");
    Console.ReadLine();
    Menu();
}