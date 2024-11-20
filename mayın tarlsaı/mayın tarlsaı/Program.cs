using System;

class Program
{
    static void Main()
    {
        int rows = 15, cols = 15;  // Mayın tarlasının boyutları
        int mineCount = 30;        // Mayın sayısı
        char[,] board = new char[rows, cols];
        bool[,] mines = new bool[rows, cols];
        Random random = new Random();

        // Tahtayı ve mayınları başlat
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                board[i, j] = '-'; // Oyuncunun tahtası
                mines[i, j] = false; // Mayınlar başlangıçta boş
            }
        }

        // Mayınları rastgele yerleştir
        for (int i = 0; i < mineCount;)
        {
            int row = random.Next(rows);
            int col = random.Next(cols);

            if (!mines[row, col]) // Eğer bu konumda mayın yoksa yerleştir
            {
                mines[row, col] = true;
                i++;
            }
        }

        // Oyun döngüsü
        bool isGameOver = false;
        while (!isGameOver)
        {
            Console.Clear();
            PrintBoard(board);

            Console.WriteLine("Bir hücre seçin (örnek: 3,4): ");
            string input = Console.ReadLine();
            string[] parts = input.Split(',');

            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int selectedRow) ||
                !int.TryParse(parts[1], out int selectedCol) ||
                selectedRow < 0 || selectedRow >= rows ||
                selectedCol < 0 || selectedCol >= cols)
            {
                Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin!");
                Console.ReadKey();
                continue;
            }

            // Kullanıcı seçimi kontrol et
            if (mines[selectedRow, selectedCol])
            {
                Console.Clear();
                Console.WriteLine("BOOM! Mayına bastınız. Oyun bitti!");
                isGameOver = true;
                RevealMines(board, mines);
                PrintBoard(board);
            }
            else
            {
                // Etrafındaki mayın sayısını bul
                int mineCountAround = CountMinesAround(selectedRow, selectedCol, mines);
                board[selectedRow, selectedCol] = mineCountAround == 0 ? ' ' : mineCountAround.ToString()[0];
            }

            // Oyun bitiş kontrolü (tüm güvenli alanlar açıldı mı?)
            if (IsGameWon(board, mines))
            {
                Console.Clear();
                Console.WriteLine("Tebrikler! Tüm güvenli alanları açtınız!");
                PrintBoard(board);
                isGameOver = true;
            }
        }

        Console.WriteLine("Oynamak için bir tuşa basın...");
        Console.ReadKey();
    }

    static void PrintBoard(char[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int CountMinesAround(int row, int col, bool[,] mines)
    {
        int count = 0;
        int[] directions = { -1, 0, 1 };

        foreach (int dr in directions)
        {
            foreach (int dc in directions)
            {
                int newRow = row + dr;
                int newCol = col + dc;

                if (newRow >= 0 && newRow < mines.GetLength(0) &&
                    newCol >= 0 && newCol < mines.GetLength(1) &&
                    mines[newRow, newCol])
                {
                    count++;
                }
            }
        }

        return count;
    }

    static void RevealMines(char[,] board, bool[,] mines)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (mines[i, j])
                {
                    board[i, j] = '*';
                }
            }
        }
    }

    static bool IsGameWon(char[,] board, bool[,] mines)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == '-' && !mines[i, j])
                {
                    return false; // Hala açılmamış güvenli bir hücre var
                }
            }
        }
        return true;
    }
}
