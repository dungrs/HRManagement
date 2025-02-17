namespace DTO {
    public class LoaiCong {
        private string Maloai { get; set; }
        private string Tenloai { get; set; }
        private string Heso { get; set; }

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