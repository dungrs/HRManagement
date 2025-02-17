namespace DTO {
    public class Tinh {
        public  string Id { get; set; }
        public  string Tentinh { get; set; }

        // Constructor mặc định
        public Tinh() { }

        // Constructor có tham sô
        public Tinh(string id, string tentinh) {
            Id = id;
            Tentinh = tentinh; 
        }
    }
}
