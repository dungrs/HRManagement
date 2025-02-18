namespace DTO {
    public class ChucVu {
        public string Machucvu { get; set; }
        public string Tenchucvu { get; set; }
        public float Hsl { get; set; }

        // Constructor mặc định
        public ChucVu() { }

        // Constructor có tham số
        public ChucVu(string machucvu, string tenchucvu, float hsl) {
            Machucvu = machucvu;
            Tenchucvu = tenchucvu;
            Hsl = hsl;
        }
    }
}
