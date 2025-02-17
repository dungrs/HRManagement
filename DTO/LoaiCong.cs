namespace DTO {
    public class LoaiCong {
        public string Maloai { get; set; }
        public string Tenloai { get; set; }
        public string Heso { get; set; }

        // Constructor mặc định
        public LoaiCong() { }

        // Constructor có tham số
        public LoaiCong(string maloai, string tenloai, string heso) {
            Maloai = maloai;
            Tenloai = tenloai;
            Heso = heso;
        }
    }
}