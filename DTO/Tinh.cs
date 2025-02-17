namespace DTO {
    public class Tinh {
        private string Id { get; set; }
        private string Tentinh { get; set; }

        // Constructor mặc định
        public Tinh() { }

        // Constructor có tham sô
        public Tinh(string id, string tentinh) {
            Id = id;
            Tentinh = tentinh; 
        }
    }
}
