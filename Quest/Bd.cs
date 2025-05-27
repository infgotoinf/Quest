
using Microsoft.EntityFrameworkCore;

using Classes;

namespace Bd
{
    public class AppDbContext : DbContext
    {
        public DbSet<BasicChoise> DbBasicChoises { get; set; }
        public DbSet<CoolChoise> DbCoolChoises { get; set; }
        public DbSet<TimelimitedChoise> DbTimelimitedChoises { get; set; }
        public DbSet<RandomChoise> DbRandomChoises { get; set; }
        public DbSet<StrangeChoise> DbStrangeChoises { get; set; }
        public DbSet<EndMessage> DbEndMessages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use a dedicated database name instead of 'postgres'
            optionsBuilder.UseNpgsql("Host=localhost;Database=QuestDB;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choise>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever();

                entity.Property(e => e.ChoisesId)
                    .HasColumnType("integer[]");

                entity.Property(e => e.ChoisesText)
                    .HasColumnType("text[]");
            });
        }
    }

    public class Database
    {
        public AppDbContext context { get; set; }

        public void DeleteDb()
        {
            context.DbBasicChoises      .RemoveRange(context.DbBasicChoises);
            context.DbCoolChoises       .RemoveRange(context.DbCoolChoises);
            context.DbTimelimitedChoises.RemoveRange(context.DbTimelimitedChoises);
            context.DbRandomChoises     .RemoveRange(context.DbRandomChoises);
            context.DbStrangeChoises    .RemoveRange(context.DbStrangeChoises);
            context.DbEndMessages       .RemoveRange(context.DbEndMessages);

            context.SaveChanges();
        }

        public void CreateDb()
        {
            context = new AppDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 0,
                    Text =
                    "   Вы проспаетесь в автобусе, ваши действия:\n\n" +
                    "@@@@#!?G@@P~~Y?^:77?JB#B?^J5GYP555555Y5Y55555P5G@@#PGBGGGG#B\r\n@@@@@BBGPB&&5~7J??J??YB#BP5YBYG57YYY57?5PPGGG#&@BPP55PPPPPY?\r\n~!Y#BG5JJY5G&&G77JYYJ?5BBGY?BJGPJJJ55J?JY5G#@&#BPPP55BGG7~!7\r\n@&PPGP5JJJY5P&@@Y!7?!!?5GY77YY&B@@&G5B&&&&YPPYGGGYG5JYYY^:..\r\n@@@&GPYJ??JY5B@@PP#!^~!7??7~!5PPBGPJPPB###7!?YJ5Y?77??5!.::~\r\n###B5J??7??JYG#&5B@J7J?7~:.:^5~7J^^~PP7::^:.~7777!^7GBP^:7Y5\r\nP5J?7!~~~~~^^P&&5&@5~^:..:^~!!!~!~!~?555~~. !::~7J75&#Y.^5##\r\nJ77??7!777!!:.7B#&@!.7::7??JYY?7YYGG5!^~!G5:!::.75YPBJ?!~5B#\r\n..::^::~^::::.^~P#7::.:::^^:::^^:^^^:...!PP!7~!!J5YGP77~7PB#\r\n.:^^^^:^~::^:::~!?:.^::..:::..::.:......~5JJYYPP555B#5^.!GB#\r\n:::^:::::::^:..:.^^::..:::...::::^:..::.~P5PGG5YY55B&G!~?P5P\r\n^:^^^::::::^:....:~^...:^^:..:::.::::...~JYGP75PPPYGB5.:!PBB\r\n.:^^^^~~~::.... .~^:....:^^^.:^^::~~:...:?YGGPP5Y5YJYJ.:YGG#\r\n~:~~^^~^^::::.: .!^.^::..:::::^^:^~:.:...?5GGP5??Y7~J7.^P#P#\r\n::^^^~~^:^~~^.. .~^.:^^:....:^^^^^~~::^:.!5GPPYJJY7!Y~.~B#GG\r\n:~~~~^~^^^^:::. .::.^~^:^^^^:^~:::::^:~~:~5G5Y?!!!^:J:.7#&BJ\r\n:^^^::^~!::.::. ^^:.::.:::^^:^~^:.::.:^^.!PPY?7^::::J:.7Y5Y7\r\n:^~~^^!!^::.....~~:.....:::::^^^:^^^:....^PPYJ7!:...Y^::^::^\r\n.::^::~^:^::..  ::...:..:^^^.:^:::::.....^GPPPPP5Y?JY7~!7!^^\r\n::^^^:~~^^^::   ^..::::......::::^:..^::.^GGGGGGBBBG5PY!!Y55\r\n..:...::::^:.  .::.....:::...:::.::......!GGGGGGGGGGGPJ77?J5\r\n..::......^^...:^^:.....::::.:^:.:^^^....~GGGGGGGJJPG7777777\r\n::::::^^::^^^:.^!^::^:.:^^^::^^^::^^::~^^!JPPPPPP?77?!7!!!!7\r\n:^^~~~~~^~!~^::^~!!!!!^~~~^^^^^^~~!~:^~7!~!75PPPY77!!!!!!!!!\r\n~^~~~7!~!~^:.:^^~~~!!^!!~^^~~!~^^~^::!~!~^~!7YYYJ?!!!~~~~~~~\r\n^^~!!~~7?!^.~^^^:::::^~~^^~~~^~^^!!~:::::::^^!JJJ?7!~~~~~~~~\r\n:^~~~^~~~. ^^^!!~^:^::~:^:::::::^!~!^:~~~~^^~^7J???7!~^^^^^^\r\n::^!77!^: :~:~!~^.::^::^:...::.:::^^^^^~!!~:^~~7??777!~::::^",
                    ChoisesId = new int[] { 1, 2, 3 },
                    ChoisesText = new string[]
                    {
                        "Остановить автобус",
                        "Заорать на весь автобус",
                        "Продолжить спать"
                    }
                }
            );
            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 1,
                    Text =
                    "   Вы быстро забегание в кабину к водителю и со всей со\n" +
                    "всей силы наступаете на педаль тормоза. Но оказывается, что\n" +
                    "вы немного ТоРмОзНуЛи и нажали на педаль газа. Пассажиры в\n" +
                    "шоке, водитель в шоке, вы в шоке, я в шоке, ваши действия?\n\n" +
                    "\r\n        .                     ............ ....  .:^~?J?^:!^\r\n                                   ......  .......:~7775P7::\r\n                                 ...............^^::~!7!JB~.\r\n                 .:^^^^:.  .   .~7^......... ....~!^^^7?YBP:\r\n                ..~JJ!:.   .. :?GB57!^..     ..^!YGGY!7YBB5:\r\n..::^::.         ...        ^.~PBB###GY!~^^^~!7YG&&&B?Y5Y5:.\r\nY55YYYY?~.   .             .?:JGB##&&&#BGGGPGGGB#&&&&Y?Y??:.\r\nP555YYYYJ?^                .7:JG##&&&###BBBBBBGBB#&&&G7J?!?^\r\nBGGBP5YY55Y!:              .!.~YY5G#&&#####B#B####&&&5JGBY?!\r\n&####GPPPPP5J!:    .        .:^77^:~?5B#BBBBBGGPG#&&#YPJ^?PP\r\nG#&&&&BPPGBP5J?~.  .. ...    ^7PG5Y5YJ~???7!^:~~!YGG55!  .^?\r\nY5G&&&&#GBBBGG5??:.......    :YYPBB#BP?G5!5YYJY5PY5#G7.    .\r\n555PB&&@&###BBP55YJ?!~^:.     YPGPP5PG###PPGBBBBBB&PJ:.    .\r\n5PPPPPB&&&&####BBGGGP5YY!.    ^PGPYYPB#&&&P?PBB###Y!!:      \r\nPPPPPPP#&&&&&&&&#GPG#&#PPJ^    ~GPY??JYPPP55G###5~~^^.      \r\nPPPGGGG&@&&&&&&&@&GJP##BP?.     :!77!!!!7?YYB#G7 :!~^.      \r\n5PGGGPJY&@&&&@@#B##5Y5##GP!......   ..^!YPGPPY!..:~~^:      \r\nPPP5J!7JPG&&&B#BYY##PYB&#G5:......::::::^7G&#G?~~:^^^:..    \r\nPY?7~!~:..^Y5JYBB5P&#PY&&BP!. !5!....... ..!5G##G!:.::..    \r\n!^..  .....:^~!~J5YG#PJ!55~...~G&P7~~!77~.   .:~J5Y7:...  ..\r\n.   .~^:.  .:^^:::^!!^::::::::^?G&#Y!~^^^:..     .:~7!:  ...\r\n   !PGG?^.  .~J~^^~!?7!!:!7!~7?!YPYY?~~^!7~~:^  ~^:!7!!: ...\r\n  .!!!77~^:.:5BY:!5P?YG~:P~5GYYYG55PGGGPPG5PJB55G^7GG7.?!...\r\n   ......::::^:^:::::::::^:~~!!77^~~!!!:.:....:^!YY~...^PP5~\r\n .:^^::::.:::...........::^^~!7JJJ??!^::...... .7Y5!. .^?J&&\r\n^^::::::.................::^~!!?Y5GBGPJ~:...... .~P?...:!YG&\r\n:::......................:::^~~7J5PGBB##GJ^...  :!?GBBBBB#&@\r\n:::.......................::^~~!?JYPGB####BY^.  :~!?YJ?!G#G#",
                    ChoisesId = new int[] { 4, 5},
                    ChoisesText = new string[]
                    {
                        "Водить автобус",
                        "Прыгнуть в лобовое стекло"
                    }
                }
            );
            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 2,
                    Text = "",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {
                    }
                }
            );
            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 3,
                    Text = "",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {
                    }
                }
            );
            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 4,
                    Text =
                    "   Вы садитесь за место водителя и люто едите не сбавляя\n" +
                    "скорости, но вдруг тут оказывается, что вы едите к обрыву\n" +
                    "в пропасть со скоростью 300 км/ч. Что вы будете делать!?!?\n\n" +
                    "BBBBBBBBBBBB##########&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@\r\nBBBBBBBBBB##########&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@\r\nBBBBBBBB##########&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@&###\r\nBBBBB############&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@&BP5J77!\r\n##############&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@#J7!!!!77!7\r\n###########&&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@B!~~!~~~~^^~~\r\n#######&&&&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@&P~^^^^^^^^^^~~\r\n#&&&&&&&&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@#J~^^^~^^^^:.^~~~\r\n&&&&&&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@BBP^::^^^^:^~:.:^^~^\r\n&&&&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@J^^^^::..:::^~..:^^~~\r\n@@@&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@5^^^::^:....:.:..::^^^\r\n&&@@@@@@@@@@@@@@@@@@@@@&@@@@@@@@@@@@#?^^:^^^~~!~7~!!77?JJYJJ\r\n@@@@@@@@@@@@@@@@@@@@B!^^^~~!!!7??J?J??J??JJJY5PPGBBB##BBB#BG\r\n&&&&&&&&@@@@@@@@@@@@@?::^^^::::..::.::::::::::::^~^:~~:.::::\r\n#BBBBBB#####&&&&&&&&&B^^^^^::::::^:::::::^:::..^^~^^^^..::^^\r\nBB##GGG##GBBB#########7^^^:::::::^^:::::::.:::.^^^^^:^:.:::^\r\nGPPBBGGGGGGBBBB#BB#BBB5^^^^::::::^^::::::^.:::.:^~^^::..:::^\r\nB55PGPPGGPGGGGGGPY5JJ55!^^^::^:::^^::::^::.:::.:^~^:::..:.::\r\nGP55PGBGGPP5PPP5JYYYYJY?^^^::::::^^::^^^::::::.:^^^:::..::::\r\nB##GPPGPPP5?J5Y?J5PPP5YJ^^^:::.^^:::.:::::::::.:^^::::..::::\r\nG&&&BGP5YYPGGGGPGBB5J7?J^^^:::::^^:..:::::::::.^^::::.......\r\nGJYG#BGPGGGGP5GGBP5????!^^^::::^:::.:::::^:::..^^:.:^.......\r\n#5!?YYGGPBBBBBB##BP77JJ7^^^:::::::::.:::::.::.:::..:^.......\r\n&BJ!!7YPGBB###BB#G5YYY57^^^:::::::::.::::....:::.:.::. .....\r\n&B5J7!?J555G#GJY55PPPPP7^^^::.:::::::.........::.:..:.......\r\nB5YY?!5GGGBGGPYY555555P~^^:^::.:::::.::.......:....::. ... .\r\nGP5GPG5&BBPYJJYYYYY555J^^:.::..:::::.:.............::.....^!\r\nP5YPYJ7????JJJJJYYYYY!::::.::.::::...............:::^...:^::",
                    ChoisesId = new int[] { 6, 7, 8 },
                    ChoisesText = new string[]
                    {
                        "Свернуть налево",
                        "Свернуть наверх",
                        "Свернуть вниз"
                    }
                }
            );
            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 5,
                    Text = "",
                    ChoisesId = new int[] {},
                    ChoisesText = new string[]
                    {
                    }
                }
            );
            context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 6,
                    EndId = 1,
                    Text =
                    "   Вы сворачиваете направо, но там оказывается кирпичная\n" +
                    "стена и не успев доехать до неё на вас падает рояль и вы\n" +
                    "взрываетесь от колёс. КОНЕЦ\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@G&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@5.?@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@?7B@@@@Y.:.G@@&P@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@#G#@@@@@@@@P..:?BJ.:~::#5::@@@&5~#@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@G^:7YG&@@@@:^^:..:~?!:.::~&5~:.?@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@Y^^~^^!YB~:?7~^~?5J^^7^.::~^^@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@&7^77!^:::7P5J?P#P?YY~~?J~.7G5YJ?7J#@@@@@@@@@@@\r\n@@@@@@@@@@@@@@&Y:~YGPY775#BG#&#GB55GP7^^^::::^5&@@@@@@@@@@@@\r\n@@@@@&GY7!~^^:::::^?G##BG#&&&&&&##&B5YYYJ7~7B@@@@@@@@@@@@@@@\r\n@@@@@@@#Y!^:^~77?JJYYG#&&&&&&&&&&&&###GJ~:.?PB&@@@@@@@@@@@@@\r\n@@@@@@@@@@@#57~!?5G#&&&&&&&&&&&&&&&&#G5J?7~^:::^!JP#&@@@@@@@\r\n@@@@@@@@@@@@@@@5::~75G#&&&&&&&&&&&&&&&#BGPY?!~^^~!?5#@@@@@@@\r\n@@@@@@@@@@@@@G!::~7YG#&&&&&&&&&&&&&&&B5?!^:7G#&&@@@@@@@@@@@@\r\n@@@@@@@@@@#J::^!?YPGBBGG#&&&&&&&&&&&##BGY!^^?#@@@@@@@@@@@@@@\r\n@@@@@@@&P~.::~!!!!77~:7B&&#&&&&&&#&&BJ!!7!!^:.^P&@@@@@@@@@@@\r\n@@@@@@@&B#&&&&&@@@@P!YBG5JJ#&#B&&GYP##Y^:5GP5YJ7J#@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&?!?7~^::7BB5?Y#B7:^75P7~B@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@Y::::~75B^75?~::?P?:~5!~!!^?&@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@#?7YG#@@@@@~!!^.~7:~?:!@@&P7~:^G@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@&@@@@@@@@@@~^::5@@G::^^@@@@@&BJ~7&@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@:.?&@@@@&7.:@@@@@@@@@B5#@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@?#@@@@@@@@G^&@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] {},
                    ChoisesText = new string[] {}
                }
            );
            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 7,
                    Text =
                    "   Вы со всей силы пытаетесь повернуть наверх но у вас не выходит... Уже\n" +
                    "близко обрыв... Вы полностью садитесь в кресло машиниста и проникаетесь всеми\n" +
                    "самыми умными мыслями, которые когда либо думали: ваш мозг работает на 101%,\n" +
                    "мышцы напряжены... Вы собираетесь и прямо перед обрывом автобус взмывает воздух\n" +
                    "и вы делаете сальто автобусом в небе.\n\n" +
                    "????!^:........^77!!7?YPGG##&&&&###GPPGY!!5&#?^:........:^!7\r\n^:.::^~~~^::.:::^7YPPB###BBB##BBBBPG#&##&&&G7~^:::::^~77!~:.\r\n.....  ..:^~!!77J5B#BBBBBGY?PGY5G5J5PG#&@&&&B5!!!7???!~^:...\r\n~^:........:^~7P##BBGGGGG5PJJYYYJJYYG#&B####&&BJ7!!7JYJ?!~^^\r\nBBBBGP5YJ????Y#&#PPPGGGGBGPG??Y7JJGBB55YGGBB##&B??JG&@&&G5YJ\r\n..::^~!?YPB#&@@&&####GG#&&##BJ?JPGPYJ?J5PYGB#&&&BP5PG#&B57^:\r\n^:^^^^~7JP&@@&#&#BBBG5G#&@&#GPPPY?JYYPY5YP5GPB#&B?7!77?7~^::\r\n^:^^^^~!?5#@@&&#P55Y7??JPGBBJ7!?Y555YY7J?PPPGB#&BJ7!~~^^::..\r\n......::^!##BB#P?57YJ?J5GPP?7!!!??P5GBBPGGGBB##&PJ?7777?777!\r\n......::~J#GGBGYYYG55JY5J?7!~~77YY775J5PBBBB&#&&5J7~::::::^^\r\n:^~~~~~^^PBPY5GPPGBY????7~~!7?77?PJ?Y5YYYGB#&&&BYJJ?!^::....\r\n!~^^:::::7#GPPP5YYPG5Y?7YJ7!JJ7?J5GYJ7J55PB###BPJ~^~~!777~^:\r\n:^~~~~~^!7GP5Y77???777?J777!YP5GPPGP5P55PBGY?J5GJ^::...:^~7?\r\n~!YGGBGG5!JJ!Y^^!JY57~^^::.:~~~7YG5GP#B5J77?J!^~77!:........\r\n!Y#@@@#5!:?YP5....^?!:..:...::::^?JYGJYY7~:7!:^^::^!7~:....:\r\nP5YJYYJ7~:^GG^.....:^............:~~5Y!??^^:^!::.....~??~^::\r\n:.:^^^^^::.Y! ...................:^~7BJ77~~^~..........^?5YJ\r\n.......:..:!      ............::^~!!!JBJPG5:..........::^!5#\r\n. ........:~::.............::^^~~!!!!!B&GGB^..........::^~?5\r\n   .  .... .5Y^...........::^^~~~~~!7YG&G5YJ~....  ....::^~!\r\n.         ..^J^............:^^^~~~!?5?~Y&Y^:?7:.   .......::\r\n        .... !?~^::.....::^^^^^~!J5?^.^!BG^.:~?!:.     .....\r\n        .... .Y7^^::.::::^^~!7YPPJ^..:^~!#Y:.::~77~.        \r\n         .... :7!^:.::^!7?J555Y7^....::::Y&?~^^::~7?!:.     \r\n         .....  .::::^~?75PJ!^:..  ...::~?&&#5?~::::~!!^.   \r\n        . ...         .:.^Y7^...    ..:^7Y#@@G?~:.....:^~^..\r\n        ....              :~..      ..::~7YB&P~:...      .:^\r\n          ..               .         ....::^G#~..           ",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[] { }
                }
            );
            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 8,
                    Text = "",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {
                    }
                }
            );
            context.SaveChanges();
        }
    }
}