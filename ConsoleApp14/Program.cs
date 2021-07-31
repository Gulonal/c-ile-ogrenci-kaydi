using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Kayıt Eklemek İçin E Kayıt Silmek için S Tuşuna Basınız");
                string secim = Console.ReadLine();
                if (secim.ToLower() == "e")
                {
                    Console.WriteLine("Kaydı Eklenecek Öğrencinin Adını Giriniz");
                    string isim = Console.ReadLine();
                    Console.WriteLine("Kaydı Eklenecek Öğrencinin Soyadını Giriniz");
                    string soyad = Console.ReadLine();
                    Console.WriteLine("Kaydı Eklenecek Öğrencinin Numarasını Giriniz");
                    string no= Console.ReadLine();
                    Ogrenci o=new Ogrenci();
                    o.Isim = isim;
                    o.Soyad = soyad;
                    o.No = no;
                    if (o.Insert())
                    {
                        Console.WriteLine("Bir Kayıt Başarıyla Eklendi");
                    }
                    else
                    {
                        Console.WriteLine("Kayıt Ekleme Başarısız Lütfen Tekrar Deneyiniz.");
                    }

                }
                else if (secim.ToLower() == "s")
                {
                    Console.WriteLine("Kaydı Silinecek Öğrencinin Numarasını Giriniz");
                    string no= Console.ReadLine();
                    Ogrenci o=new Ogrenci();
                    DeleteResult sonuc=o.Delete(no);
                    Console.WriteLine(sonuc.DeletedCount +" Kayıt Başarıyla Silindi");
                }
            }
        }
    }
}
