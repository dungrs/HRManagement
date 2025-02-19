namespace DTO {
    public class KhauTru {
        public string Makt { get; set; }
        public string Tenkt { get; set; }
        public float Tien { get; set; }

        // Constructor mặc định
        public KhauTru() { }

        // Constructor có tham số
        public KhauTru(string makt, string tenkt, float tien) {
            Makt = makt;
            Tenkt = tenkt;
            Tien = tien;
        }
    }
}
