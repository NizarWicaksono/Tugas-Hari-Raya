using System;

class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.Nama = nama;
        this.ID = id;
        this.GajiPokok = gajiPokok;
    }

    public virtual double HitungGaji()
    {
        return GajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    private const double BonusTetap = 500000;

    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok + BonusTetap;
    }
}

class KaryawanKontrak : Karyawan
{
    private const double PotonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok - PotonganKontrak;
    }
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Pilih jenis karyawan:");
        Console.WriteLine("1. Karyawan Tetap");
        Console.WriteLine("2. Karyawan Kontrak");
        Console.WriteLine("3. Karyawan Magang");
        Console.Write("Pilihan Anda (1/2/3): ");
        int pilihan = Convert.ToInt32(Console.ReadLine());

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();
        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();
        Console.Write("Masukkan Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan; 

        switch (pilihan)
        {
            case 1:
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
                break;
            case 2:
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
                break;
            case 3:
                karyawan = new KaryawanMagang(nama, id, gajiPokok);
                break;
            default:
                Console.WriteLine("Pilihan tidak valid!");
                return; 
        }

         Console.WriteLine($"Gaji akhir karyawan atas nama {karyawan.Nama} dengan ID {karyawan.ID} adalah Rp {karyawan.HitungGaji()}");
    }
}