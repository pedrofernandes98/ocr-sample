using Tesseract;

namespace ocr_sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o programa");

            var path = "C:\\dev\\playground\\ocr-sample\\teste.png";

            try
            {
                using (var engine = new TesseractEngine(@"C:\dev\playground\ocr-sample\src\tessdata", "por", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(path))
                    {
                        using(var page = engine.Process(img))
                        {
                            var text = page.GetText();

                            Console.WriteLine($"Taxa de precisão: {page.GetMeanConfidence()}");
                            Console.WriteLine(text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Fim do programa");
                Console.ReadLine();
            }
        }
    }
}