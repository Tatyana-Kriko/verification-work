void SendMasage(string str){
    if(str.Length>=0){
        Console.WriteLine(str);
    }
    Console.WriteLine("Нажмите ENTER");
    Console.ReadLine();
}

string[] getResult(string[]arr){
    string[] res = {};
    for (int i = 0;i<arr.Length; i++){
        if(arr[i].Length<=3){
            res = res.Append(arr[i]).ToArray();
        }
    }
    return res;
}



while (true){
    Console.Clear();
    int choose;
    Console.WriteLine("Выберите действие");
    Console.WriteLine("1) Считать массив с клавиатуры");
    Console.WriteLine("2) Считать массив с файла");
    Console.WriteLine("3) Завершить программу");
    choose = Convert.ToInt32(Console.ReadLine());
    if (choose == 1){
        try{
            string[] res = {};
            Console.Clear();
            Console.WriteLine("Введите массив через проблел");
            string[] arr = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
            res = getResult(arr);
            if(res.Length == 0){
                SendMasage("Результат пустой");
            }
            else{
                Console.WriteLine("Результат:");
                foreach(string str in res){
                    Console.Write($"{str} ");
                }
                SendMasage("");
            }
        }
        catch{
            SendMasage("Возникло исключение!");
        }
    }
    else if (choose == 2){
        try{
            string[] res = {};
            Console.Clear();
            Console.WriteLine("Укажите путь до файла");
            string path = Console.ReadLine();
            FileInfo fileInf = new FileInfo(path);
            if(fileInf.Exists){
            using (Stream stream = new FileStream( path, FileMode.Open ))
            using (TextReader reader = new StreamReader(stream))
                {   
                    string contents = reader.ReadToEnd();
                    string[] arr = contents.Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                    res = getResult(arr);
                    if(res.Length == 0){
                    SendMasage("Результат пустой");
                    }
                    else{
                        Console.WriteLine("Результат:");
                        foreach(string str in res){
                            Console.Write($"{str} ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите ENTER");
                        Console.ReadLine();
                    }
                }
            }
            else{
                SendMasage("Файла не существует");
            }
        }
        catch{
            SendMasage("Возникло исключение!");
        }
    }
    else if (choose == 3){
        break;
    }
    else{
        SendMasage("Неверный ввод");
    }

}
