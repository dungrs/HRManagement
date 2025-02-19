namespace DTO {
    public class LoaiCa {
        public string Maloai { get; set; }
        public string Tenca { get; set; }
        public float Heso { get; set; }

        // Constructor mặc định
        public LoaiCa() {  }

        // Constructor có tham số
        public LoaiCa(string maloai, string tenca, float heso) {
            Maloai = maloai;
            Tenca = tenca;
            Heso = heso;
        }
    }
}
