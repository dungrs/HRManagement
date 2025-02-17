namespace DTO {
    public class PhuCap {
        public string Maloaipc { get; set; }
        public string Tenloai { get; set; }
        public string Tien { get; set; }

        // Constructor mặc định
        public PhuCap() { }

        // Constructor có tham sô
        public PhuCap(string maloaipc, string tenloai, string tien) {
            Maloaipc = maloaipc;
            Tenloai = tenloai;
            Tien = tien;
        }
    }
}
