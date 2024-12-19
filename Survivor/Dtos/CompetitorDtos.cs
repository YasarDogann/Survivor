namespace Survivor.Dtos
{
    public class CompetitorDtos
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CategoryId { get; set; }
    }
}

/*
 DTO Nedir?

DTO (Data Transfer Object) bir nesnedir ve genellikle aşağıdaki amaçlarla kullanılır:

1.Veri Transferini Basitleştirmek:
  - Veritabanı modellerinde (örneğin Competitors) fazla ya da hassas veriler olabilir. DTO'lar, yalnızca gerekli olan verilerin taşınmasını sağlar.
  - Örneğin: CreatedDate, ModifiedDate, veya IsDeleted gibi veritabanı alanlarını istemciye göndermenize gerek yoksa bunları DTO’da tutmazsınız.

2.Güvenlik Sağlamak:
  - DTO, istemciye (frontend) yalnızca gerekli olan verileri gönderir ve gereksiz hassas verileri dışarıya sızdırmaktan kaçınırsınız.
  - Örneğin: Competitors içinde bir Navigation Property ya da özel veriler varsa, bunları DTO'ya koymazsınız.

3.Model ile İstemci Arasında Bağımsızlık Sağlamak:
  - Competitors modeli doğrudan frontend'e gönderilirse, veritabanı yapısındaki bir değişiklik istemciyi etkileyebilir. DTO'lar bu bağımlılığı kırar.
 
 
 
 
 
 */