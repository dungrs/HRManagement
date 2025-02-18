namespace DTO {
    public class BoPhan {
        public string Mabophan { get; set; }
        public string Tenbophan { get; set; }

        // Constructor mặc định
        public BoPhan() { }
        
        // Constructor có tham số
        public BoPhan(string mabophan, string tenbophan) {
            Mabophan = mabophan;
            Tenbophan = tenbophan;
        }
    }
}
