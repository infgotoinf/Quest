
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
            optionsBuilder
                .UseNpgsql("Host=localhost;Database=QuestDB;Username=postgres;Password=1234")
                .EnableSensitiveDataLogging();
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
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 1,
                    Text =
                    "   Вы быстро забегание в кабину к водителю и со всей со\n" +
                    "всей силы наступаете на педаль тормоза. Но оказывается, что\n" +
                    "вы немного ТоРмОзНуЛи и нажали на педаль газа. Пассажиры в\n" +
                    "шоке, водитель в шоке, вы в шоке, я в шоке, ваши действия?\n\n" +
                    "\r\n        .                     ............ ....  .:^~?J?^:!^\r\n                                   ......  .......:~7775P7::\r\n                                 ...............^^::~!7!JB~.\r\n                 .:^^^^:.  .   .~7^......... ....~!^^^7?YBP:\r\n                ..~JJ!:.   .. :?GB57!^..     ..^!YGGY!7YBB5:\r\n..::^::.         ...        ^.~PBB###GY!~^^^~!7YG&&&B?Y5Y5:.\r\nY55YYYY?~.   .             .?:JGB##&&&#BGGGPGGGB#&&&&Y?Y??:.\r\nP555YYYYJ?^                .7:JG##&&&###BBBBBBGBB#&&&G7J?!?^\r\nBGGBP5YY55Y!:              .!.~YY5G#&&#####B#B####&&&5JGBY?!\r\n&####GPPPPP5J!:    .        .:^77^:~?5B#BBBBBGGPG#&&#YPJ^?PP\r\nG#&&&&BPPGBP5J?~.  .. ...    ^7PG5Y5YJ~???7!^:~~!YGG55!  .^?\r\nY5G&&&&#GBBBGG5??:.......    :YYPBB#BP?G5!5YYJY5PY5#G7.    .\r\n555PB&&@&###BBP55YJ?!~^:.     YPGPP5PG###PPGBBBBBB&PJ:.    .\r\n5PPPPPB&&&&####BBGGGP5YY!.    ^PGPYYPB#&&&P?PBB###Y!!:      \r\nPPPPPPP#&&&&&&&&#GPG#&#PPJ^    ~GPY??JYPPP55G###5~~^^.      \r\nPPPGGGG&@&&&&&&&@&GJP##BP?.     :!77!!!!7?YYB#G7 :!~^.      \r\n5PGGGPJY&@&&&@@#B##5Y5##GP!......   ..^!YPGPPY!..:~~^:      \r\nPPP5J!7JPG&&&B#BYY##PYB&#G5:......::::::^7G&#G?~~:^^^:..    \r\nPY?7~!~:..^Y5JYBB5P&#PY&&BP!. !5!....... ..!5G##G!:.::..    \r\n!^..  .....:^~!~J5YG#PJ!55~...~G&P7~~!77~.   .:~J5Y7:...  ..\r\n.   .~^:.  .:^^:::^!!^::::::::^?G&#Y!~^^^:..     .:~7!:  ...\r\n   !PGG?^.  .~J~^^~!?7!!:!7!~7?!YPYY?~~^!7~~:^  ~^:!7!!: ...\r\n  .!!!77~^:.:5BY:!5P?YG~:P~5GYYYG55PGGGPPG5PJB55G^7GG7.?!...\r\n   ......::::^:^:::::::::^:~~!!77^~~!!!:.:....:^!YY~...^PP5~\r\n .:^^::::.:::...........::^^~!7JJJ??!^::...... .7Y5!. .^?J&&\r\n^^::::::.................::^~!!?Y5GBGPJ~:...... .~P?...:!YG&\r\n:::......................:::^~~7J5PGBB##GJ^...  :!?GBBBBB#&@\r\n:::.......................::^~~!?JYPGB####BY^.  :~!?YJ?!G#G#",
                    ChoisesId = new int[] { 4, 5 },
                    ChoisesText = new string[]
                    {
                        "Водить автобус",
                        "Прыгнуть в лобовое стекло"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 2,
                    Text = "Вам не хочется орать",
                    ChoisesId = new int[] {1},
                    ChoisesText = new string[]
                    {
                        "Остановить автобус"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 3,
                    Text = "Вам не спится",
                    ChoisesId = new int[] {1},
                    ChoisesText = new string[]
                    {
                        "Остановить автобус"
                    }
                }
            ); context.DbBasicChoises.AddRange(
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
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 5,
                    Text =
                    "   Лобовое стекло настолько красивое, что его ломать не хочется",
                    ChoisesId = new int[] {4},
                    ChoisesText = new string[]
                    {
                        "Сесть за место водителя"
                    }
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 6,
                    EndId = 1,
                    Text =
                    "   Вы сворачиваете направо, но там оказывается кирпичная\n" +
                    "стена и не успев доехать до неё на вас падает рояль и вы\n" +
                    "взрываетесь от колёс. КОНЕЦ\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@G&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@5.?@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@?7B@@@@Y.:.G@@&P@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@#G#@@@@@@@@P..:?BJ.:~::#5::@@@&5~#@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@G^:7YG&@@@@:^^:..:~?!:.::~&5~:.?@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@Y^^~^^!YB~:?7~^~?5J^^7^.::~^^@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@&7^77!^:::7P5J?P#P?YY~~?J~.7G5YJ?7J#@@@@@@@@@@@\r\n@@@@@@@@@@@@@@&Y:~YGPY775#BG#&#GB55GP7^^^::::^5&@@@@@@@@@@@@\r\n@@@@@&GY7!~^^:::::^?G##BG#&&&&&&##&B5YYYJ7~7B@@@@@@@@@@@@@@@\r\n@@@@@@@#Y!^:^~77?JJYYG#&&&&&&&&&&&&###GJ~:.?PB&@@@@@@@@@@@@@\r\n@@@@@@@@@@@#57~!?5G#&&&&&&&&&&&&&&&&#G5J?7~^:::^!JP#&@@@@@@@\r\n@@@@@@@@@@@@@@@5::~75G#&&&&&&&&&&&&&&&#BGPY?!~^^~!?5#@@@@@@@\r\n@@@@@@@@@@@@@G!::~7YG#&&&&&&&&&&&&&&&B5?!^:7G#&&@@@@@@@@@@@@\r\n@@@@@@@@@@#J::^!?YPGBBGG#&&&&&&&&&&&##BGY!^^?#@@@@@@@@@@@@@@\r\n@@@@@@@&P~.::~!!!!77~:7B&&#&&&&&&#&&BJ!!7!!^:.^P&@@@@@@@@@@@\r\n@@@@@@@&B#&&&&&@@@@P!YBG5JJ#&#B&&GYP##Y^:5GP5YJ7J#@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&?!?7~^::7BB5?Y#B7:^75P7~B@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@Y::::~75B^75?~::?P?:~5!~!!^?&@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@#?7YG#@@@@@~!!^.~7:~?:!@@&P7~:^G@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@&@@@@@@@@@@~^::5@@G::^^@@@@@&BJ~7&@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@:.?&@@@@&7.:@@@@@@@@@B5#@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@?#@@@@@@@@G^&@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[] { }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 7,
                    Text =
                    "   Вы со всей силы пытаетесь повернуть наверх но у вас не\n" +
                    "выходит... Уже близко обрыв... Вы полностью садитесь в\n" +
                    "кресло машиниста и проникаетесь всеми самыми умными\n" +
                    "мыслями, которые когда либо думали: ваш мозг работает на\n" +
                    "101%, мышцы напряжены... Вы собираетесь и прямо перед\n" +
                    "обрывом автобус взмывает воздух и вы делаете сальто\n" +
                    "автобусом в небе.\n\n" +
                    "????!^:........^77!!7?YPGG##&&&&###GPPGY!!5&#?^:........:^!7\r\n^:.::^~~~^::.:::^7YPPB###BBB##BBBBPG#&##&&&G7~^:::::^~77!~:.\r\n.....  ..:^~!!77J5B#BBBBBGY?PGY5G5J5PG#&@&&&B5!!!7???!~^:...\r\n~^:........:^~7P##BBGGGGG5PJJYYYJJYYG#&B####&&BJ7!!7JYJ?!~^^\r\nBBBBGP5YJ????Y#&#PPPGGGGBGPG??Y7JJGBB55YGGBB##&B??JG&@&&G5YJ\r\n..::^~!?YPB#&@@&&####GG#&&##BJ?JPGPYJ?J5PYGB#&&&BP5PG#&B57^:\r\n^:^^^^~7JP&@@&#&#BBBG5G#&@&#GPPPY?JYYPY5YP5GPB#&B?7!77?7~^::\r\n^:^^^^~!?5#@@&&#P55Y7??JPGBBJ7!?Y555YY7J?PPPGB#&BJ7!~~^^::..\r\n......::^!##BB#P?57YJ?J5GPP?7!!!??P5GBBPGGGBB##&PJ?7777?777!\r\n......::~J#GGBGYYYG55JY5J?7!~~77YY775J5PBBBB&#&&5J7~::::::^^\r\n:^~~~~~^^PBPY5GPPGBY????7~~!7?77?PJ?Y5YYYGB#&&&BYJJ?!^::....\r\n!~^^:::::7#GPPP5YYPG5Y?7YJ7!JJ7?J5GYJ7J55PB###BPJ~^~~!777~^:\r\n:^~~~~~^!7GP5Y77???777?J777!YP5GPPGP5P55PBGY?J5GJ^::...:^~7?\r\n~!YGGBGG5!JJ!Y^^!JY57~^^::.:~~~7YG5GP#B5J77?J!^~77!:........\r\n!Y#@@@#5!:?YP5....^?!:..:...::::^?JYGJYY7~:7!:^^::^!7~:....:\r\nP5YJYYJ7~:^GG^.....:^............:~~5Y!??^^:^!::.....~??~^::\r\n:.:^^^^^::.Y! ...................:^~7BJ77~~^~..........^?5YJ\r\n.......:..:!      ............::^~!!!JBJPG5:..........::^!5#\r\n. ........:~::.............::^^~~!!!!!B&GGB^..........::^~?5\r\n   .  .... .5Y^...........::^^~~~~~!7YG&G5YJ~....  ....::^~!\r\n.         ..^J^............:^^^~~~!?5?~Y&Y^:?7:.   .......::\r\n        .... !?~^::.....::^^^^^~!J5?^.^!BG^.:~?!:.     .....\r\n        .... .Y7^^::.::::^^~!7YPPJ^..:^~!#Y:.::~77~.        \r\n         .... :7!^:.::^!7?J555Y7^....::::Y&?~^^::~7?!:.     \r\n         .....  .::::^~?75PJ!^:..  ...::~?&&#5?~::::~!!^.   \r\n        . ...         .:.^Y7^...    ..:^7Y#@@G?~:.....:^~^..\r\n        ....              :~..      ..::~7YB&P~:...      .:^\r\n          ..               .         ....::^G#~..           ",
                    ChoisesId = new int[] {9, 11},
                    ChoisesText = new string[]
                    {
                        "Выпрыгнуть из автобуса",
                        "Повернуть на 45 градусов влево"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 8,
                    Text = 
                    " Вы собираетесь свернуть вниз, но путаете вниз и верх, и\n" +
                    "поэтому едите вверх.",
                    ChoisesId = new int[] {7},
                    ChoisesText = new string[]
                    {
                        "Поезать вверх"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 9,
                    Text =
                    "   С чувством выполненного долга, вы нажимаете кнопку\n" +
                    "экстренного уничтожения автобуса, надеваете чёрные\n" +
                    "пиксельные очки и выпрыгиваете в окно. Пока вы медленно\n" +
                    "падаете вниз с парашютом, автобус за вашей спиной взрываете\n" +
                    "со всеми людьми, которые в нём были, убивая их всех до\n" +
                    "единого. Что вы с этим будете делать?\n\n" +
                    "^^:::~~~~7^^75!!5YG5!JY7??!?~7PGGP?P#####&&&##B#GY??7~~7~^^^\r\n^^::::^~^~:.~7~^~^~::^?7??JGPYJPBGGPB##&&BGGPGY5#&J7!~!!^^^^\r\n::..:^^^!^.^?Y7~J?:::::7G###J:~!?B&&&&&#G5PYJYGP#&BJ?7777!~~\r\n::...:.:!:^~7J~::..^~~:?G&#!...JYJ#&BY!7!7YPBJYYG#PB#GY?7~^^\r\n^~^::..^7~..J?^..:^!?PBPG&?..   ..~PP~:~!7J~5J~~GJ!G&PYJJJ7!\r\n?!~~7^^~^.. .::....:~P#Y7:          :J~:::~~7^^:..^5GP5YYGBB\r\nY?7??!7^^^.....:....^JG^             .!:.:::..::^77GGY5GG##G\r\n!~^~~^~^^^^......::^!55             .!!^:::::~!777JJYJ5PP55P\r\n^!~!^::::^!!^:..::~JY~. .          .:^~7!^^^~~?J!!7!7~77!!!7\r\n!7JJ7?7!7777!!!~~7?..   .          . . :?77????!~~~7~~^^^::^\r\nPGB#PB##G5GGPG555G:       :        :..  .:JYJ?7!~^^^^^::::::\r\nGBB&PB&&BG&#B#BP#P         .        .     7YJJJJJ77!~!~!!7??\r\nPGB#PG#&GG&###G#&!     .        .   .     ^P5J7JJ?YYJ5?YY5GG\r\nGPGG5GBBBP#PJ5B&B.     .        .   .     .J5J!JJY55PPJPGPBB\r\n?JY5?YPPGG#J7!7B7      .        .  . .     7P7JJ?YY5YY?5P5PP\r\n~!!?!?JYJY57?!^P:      .  .      : . ..     !PP5Y55P5Y~~!JPP\r\n~!!!!!!7!77!!7J~    .. .  .         . 7:   .7BPP555Y5J.:^!5P\r\n^~~^~~~~~~!7?5Y..   . .        .      .~   ..7P5JJ!!~^:^~::7\r\n:^^^^~!!~!7JBB?.   :J .         ....   !.  .^!BGPP7~~~^~!^~7\r\n:^77!7?!~7PG#&J.   J? .          ..:   :Y.  .:G&##PJ?J5YYJJP\r\n^^J^^~!~!!PB55..  .Y:.             ..  .P^  .^P#BG5YY5PP5Y55\r\n^~^:~::~!~~!7Y7:  :J:.    .         .  .Y?  :J77!~^^::^^::^^\r\n77^:^^:~777J5PG~:~~B:.   ..          ...5J.::??!~!^:^:.. :~!\r\nJ77?7~7YGGB&&###Y?GB:.  ..             .5B??J?7~!~:        .\r\n~^^^^^~7JJ5PPPPGGB#J. ...               :GBB5J!~!!^:..      \r\n^^:......::::^^~~!7:..:.                  :!!~^^::^^:::.:::.\r\n.:..:.........::^7J: ^^                    .:^^~??~::::^^~~~\r\n......:::..::::^^^7:.^     .                 ....::...:~!^^:",
                    ChoisesId = new int[] { 12, 12, 12 },
                    ChoisesText = new string[]
                    {
                        "Ок",
                        "Ок",
                        "Ок"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 11,
                    Text =
                    "   Вы собираетесь повернуться на 45 градусов, но передумываете.",
                    ChoisesId = new int[] {9},
                    ChoisesText = new string[]
                    {
                        "Выпрыгнуть из автобуса"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 12,
                    Text =
                    "   Смирившись с этим как последняя тварь вы приземляетесь\n" +
                    "на крышу многоэтажного здания. Вы осматриваетесь по\n" +
                    "сторонам, похоже вы в заброшенном городе. Ваши действия?\n\n" +
                    "5555555555PPPPPPPPGGGPPPPPPPPPPPPGPPPPPPPPPPPPPPPPPPPP555555\r\n55555P5555PPPPPGGGGGGGPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP55555\r\nP5555PPPPPPPPPPGGGGGGPPPPPPPPPPPPPPPPPGPGGGGGGGPPPPPPPPPP555\r\nP5PPPPPPPPPPPPPGGGGGGPPPPPPPPPPP555PPPGGGGGGGGGGGGPPPPPPPP55\r\nPPPPPPPPPPPPPPPGGGGGGPPPPP555555YYY5PPPGGGGGGGGGGGGPPPPPPPP5\r\nPPPPPPPPPPPPPGGGGGGGGPPPP555555Y??JY5PGGGGGGGGGGGGGGPPPPPPP5\r\nPPPPPPPPPPGGGGGGGGGGGP55PP5YYJJJ77??J5GGGBBBGGGGGGGGGGGPPPPP\r\nPPPGGGGGGGGGGGGGGGGGGPJJ55YJ?77?!!77?YGBBBBBBBBBBGGGGGGGPPPP\r\nGGGGGGGGGGGGGGGGGGGGG577??7!!~~!!~!!7JBBBBBBBBBBBBBBGGGGGPPP\r\nGGGGGGGGGGGGGGGGGGGBBY!!!~~~~~!~^~~~!!G##BBBBBBBBBBBBGGGGGPP\r\nPGGGGGGGGGGGBBBBBBBBBJ~~~!!!!JY?!~~~~~P##BB#BBBBBBBBBBGGGGPP\r\nGGGGGGGGGGGGBBBBBBBBB?!?5??!!~~^^^~7!~J#############BBBGGGPP\r\nGGGGGGGGGGGGBBBBBBBBBY?77~~~~~~^^^^~!!7#############BBBGGGPP\r\nGGGGGGGGGGGBBBBBBBBBB7~~~~~~~~~^:.::^~7B####BB######BBBGGGPP\r\nGGGGGGBBBBBBBBBBBBBBG~~~~~~~~~^.    :~~G###BBBBB##BBBBBGGPPP\r\nGGGBBBBBBBBBBBBBBBBBP~~~~~~^^.     .:~~Y&##BBBBBBBBBBBGGPPP5\r\nBBBBBBBBBBBBBBBBBBB#5~~~~~^.      ..:^~?&##BBBGGGGGGGGGPPP55\r\nBBBBBBBBBBBBBBBBBBB#Y~~~!:..   ..^^^^~~!###BBGGGGGGGGGGPPP55\r\nBBBBBBBBBBBBBBBBBGPP!~!77.    :^7~^..^~~GBGPGGGGGGGGGGPPPPP5\r\nBBBBBBBBBBBBBBBBBPJ.  ..:    :~~57^. .^:~:.^5GGGPPPPPPPPPP?~\r\nBBBBBBBBBBBBBBBBBB#J    .   :~~~^:         .!PGGGGGPPPPPP?  \r\nBBBBBBBBBBBBBBBBBBBGJ.     .:::~:          :~JY7?~7JPPP5!   \r\n##BBBBBBBBBBBBBBBB#G!^.    ..  . .                  ^~^:    \r\n#######BBBB####BP5G5^.      .                              .\r\nBBG55JP###B5?7JG5::^                                   .    \r\n~:.:  .~~:.    ^!?:                                         \r\n                                                            \r\n:.                                                          \r\n                                                            ",
                    ChoisesId = new int[] { 13, 14, 15 },
                    ChoisesText = new string[]
                    {
                        "Вызвать вертолёт",
                        "Взять пулемёт",
                        "Спрыгнуть с крыши"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 13,
                    Text =
                    "   Вы достаёте рацию и вызываете вертолёт. Пилот\n" +
                    "говорит вам, что прибудет через 15 минут. Вы слышите рёв\n" +
                    "тирекса в 300 метрах от вас, он приближается, что вы\n" +
                    "будете делать?\n\n" +
                    "JJJJJJJJJJJJJYJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJ?????\r\nJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJ??????\r\nJJJJJYYYJYYYJJJJJJJJJJJYJJJJJJJJJJJJJJJJJJJJJJJJJJJJ????????\r\nYYY5PGP7~!?YYYYYYYJYYJJ?YYJJJJJJJJJJJJJJJJJJJJJJJJJ?????????\r\nYY7!!??JJ?J?J??JY55Y!^:.!JYYYYYJJJJJJJJJJJJJJJJJJ???????????\r\nYJ^.:.^^!?JY?7!7JYJJ?!~7~7JJYYYYYYYYJJJJJJJJJJJJJJ???????JJJ\r\nJJ7:....^!7!?J?77775Y?J5Y7JJ?JYYYYYJJJJJJJJJJJJJJJ????JJJYYY\r\nYYJ7^:....^^^^!7JJ?5YJYGG5??7~7YYYYJJJJJJJJJJJJJJJJJJJYYYYYY\r\nJYYJY77^::....:::^~!7?Y55PY?J!7?YYYYJJJJJJJJJJJJJYYYYYYYYYYY\r\nYYYYYYYYJ?~....     .:^^~7?7???7!5YYYYJYYJJJJJJYYYYYYYYJJJJJ\r\nYY5555Y77JJ:.        :~^^::::^~7~J5YYYYYYYYYYYYYYYYYJJJJJJJJ\r\nYYY5555Y?^:::...::^~!?777!~~~^^^^!J55YYYYYYYYYYYYYJJJJJJJJJY\r\nYYY5YJYY5Y7?~^7!????7!!~~!!~^^~^~~!?5555YYYYYYYYYYYJJJJJJJJY\r\nYYY!::^^~~!!!!!!!!!7!!~~~^^^^::~~!!7J55YY5YYYYYYYYYYYYYJJJYY\r\nYYYY~::::^^^~~~~~~~~~~~^^:::~~^~7~JJ?JYY7JY5YYYY5YYYYYYYYYYY\r\nJYYYYJ7!!7777!~~^~!!!~~^^^~!^~!~!7~7?77J77YGGG57?YYJJY555PP5\r\nJJJJYYYYYYYYYYYJJY55555J~^^~!^^!~77!7~7?J5GGPPPY!?YYJ~?Y??Y5\r\n5YJJJJJJJJJJJJYBBB#B5Y5P5!~~~~!^!~7!^?5PPPG5YY5J7?J?Y~!J?!~Y\r\n#G5PPP5YJYGBBB###BBBB5Y555!^~~!~~!!!?GP5Y5YJ?7?!!7?7Y77JJ7^J\r\nGGB#BBBGG#&&####BGGPGPYY55P7^~~~!^!!PPYJYJ??7~~~~7?7Y?J??7~J\r\nGGBBB#####&##BBBGPP55YPG555P7^~~~!!7?J??7777~^~^^!77?7?77!^Y\r\nPGPPPPGBB##BGPP55YY5Y5GBP5PP5!!!!!77!~^^~!7??..~~~!7~!!!~~^7\r\n55YY55PPGGGGP5YYYYYYY55555PPPY~~!!!~~~^::?GG5!:~?7?77!~~^~^J\r\nJJJYYYYYYYYYYYYYYYYYYYYY55PPPP7::^^!!^~~!YPP5!~~?J???77~!~^P\r\nJJJJYJJJJJJJYYYYY55555PP5PPPPY~^.:7^::::^~!77!!!~~77777!!!^5\r\nYYYYYYYYYYYYY55PGGGGGGGPJ777!^::^YJ?!^~^^::::^^^~!~~!!!~~:^5\r\nYY5P55YYYYYY55555PPP5PJ::!!~~~~75PPGP?::^:::.....::^::^^: :!\r\nYYYYYYYYYYYYYYYYYYY555:^5PPPPPPPGGGPPPY!^:::::........... ::",
                    ChoisesId = new int[] { 16, 18 },
                    ChoisesText = new string[]
                    {
                        "Спрятаться в шкафу",
                        "Притвориться закуской"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 14,
                    Text =
                    "   Вы решаете взять пулемёт с патронами который лежал в\n" +
                    "коробке. Зомби уже на подходе и ломятся в дверь.\n" +
                    "Как поступите?\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&&@@@@@@@@@@&&@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&&&&&&&&############@@@@@@@&#BBB#&@@@@@@@@@\r\n@@@@@@@@@@############################@@@@@#BBBBBBBB#@@@@@@@\r\n@@@@@@@@@@@B#########################B#@@#BBBBBBBBBBBB#&@@@@\r\n@@@@#&&@@@@&B###############BBBGGPP5YYJ?JPBBBBBBBBBBBBGG#@@@\r\n@@@@@#B##&@@#BBBBBGGGPP55YJJJ??7777777!~~7YPGBBBBBBBBG#@@@@@\r\n@@@@@@&BBBB#BYJJ???7777777777777!!!!~~~^^!77JPGGGGGGB&@@@@@@\r\n@@@@@@@&BBBBBGJ!777!!!!!!!!~~~~~^^^^^::::~!!77J5GGG&@@@@@@@@\r\n@@@@@@@@@#BBBBBY~~~^^^^^^^^:::::::::.....^~!7??J5G&@@@@@@@@@\r\n@@@@@@@@@@@&#GGBY^::::::::::....:::^^~!7J55PPPPPPB&&&@@@@@@@\r\n@@@@@@@@@@@@@BGPG5^..::^^~!7?JY55PPPPPPP555555555&@@@@@@@@@@\r\n@@@@@@@@@@@@@BGGGGP?J5PGPPPP55555YYYY555555555555@@@@@@@@@@@\r\n@@@@@@@@@@@@@BGGGGG5Y55YYYYY55555555555555555555P@@@@@@@@@@@\r\n@@@@@@@@@@@@@#PGGGG5YYYYYYYYYY555555555555555555P@@@@@@@@@@@\r\n@@@@@@@@@@@@@@#PPGG5YYYYYYYYYYYYYYYYY5555555555YG@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@#PPP5YYYYYYYYYYYYYYYYYYYYYYYYYYYJB@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@&PP5YYYYYYYYYYYYYYYYYYYYYY5PPGB#@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&P5YYYYYYYYJYYYY5PPGB#&&@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@PJJYY5PPGB#&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@#&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] {55, 56},
                    ChoisesText = new string[]
                    {
                        "Прифаером прострелом им всем хэдшоты надавать",
                        "Попытаться мирно договориться"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 15,
                    Text =
                    "   Вам вдруг очень сильно на земле постоять захотелось, а\n" +
                    "этажей у вашей многоэтажки 300, поэтому ну тип лень\n" +
                    "спускаться по лестнице или ждать лифт, поэтому вы решили\n" +
                    "воспользоваться альтернативным лифтом - гравитацией. Вы\n" +
                    "берёте и тупо прыгаете и многоэтажки. Летите там...\n" +
                    "летите... и вдруг как буд-то понимаете, что что-то тут не\n" +
                    "так... Как буд-то ваш план не идеален.... Чёт медленный\n" +
                    "лифт какой-та... Ну вы и ускоряетесь силой тяжести ваших\n" +
                    "психических шизофренических отклонений, долетая до земли\n" +
                    "за полсекунды.... И вот вы в какой-то белой комнате и перед\n" +
                    "вами сидит Исус: \"Бро, чё это за кринж щас был, боже, я\n" +
                    "кнш понимаю, ты тупенький, но не настолько же. Чтоб больше\n" +
                    "так глупо не умирал, ты меня понял?\" и с этими сломами он\n" +
                    "пропадает...\n\n" +
                    "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGJ?PGGGGGGGGGGGGGGGGGGGGGPPGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGY^!5BGGGGGGGGGGGBGGGGGY5??JGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGJ ~GBGGGGGGGGGP5PBBGGP~.7PGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGB? ^YGBBGGGGG~.  :5BGB~ YBGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGB7 .!JPBBBBP:!7^ JBGJ  5BGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGB5~   :!J5J:::..?J.  :GGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGBB57:     ...      .PBGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGBBBG!           JGBGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGBB:          PBBBGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGBBB~          YBBGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGBBJ          !BGGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGBBB:         .PBGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGBBB5.          :YGBGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGB!             .?PBGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGBG:     ^!.       ~YGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGBY    5BBP?5!:.    :5BGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGBP   .BBBBBBBBGGPY. .JGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGB:   PBBBBGGGBBBBP  .PBGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGB5   :GBGGGGGGGGGB~  YBGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGGB!   PBGGGGGGGGGGGYYGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGGB7  7BGGGGGGGGGGGGBBGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGGB^  5BGGGGGGGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGGGPJPBGGGGGGGGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGGGGBGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG",
                    ChoisesId = new int[] {58},
                    ChoisesText = new string[]
                    {
                        "Воскреснуть"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 16,
                    Text =
                    "   Вы прячитесь в шкафу, тираннозавр ломает стену и\n" +
                    "пристально дышит прямо на вас через шкаф, но уже через 14\n" +
                    "минут уходит. Вы вылезаете из шкафа и видите, как вертолёт\n" +
                    "уже близко, но годзила лазерным взглядом испепеляет, после\n" +
                    "чего тот взрывается. Что теперь?\n\n" +
                    "77???7????????????JJ???JJYYYJJ????77777777!!!!!!!~~~~!!!!!~~\r\n!777??????????JJ?JJJJ???JJYYYJ??777777!!!!!!~~~~~~~~~~!!!!~~\r\n777777?????????JJJYYJ??77!!!777777777777!!!!!~~~~~^^^~~!!~~~\r\n!!777777??JJJYY5PGGGGBBGPJ7!~^^^~!!7!!!!!!~~~~^^^^^^^^~~~~~~\r\n!!!777??JY5PGB#&&&&@@@@@&&P7~^^::::^~!!~~~~~~~~~^^^^^^~~!!~~\r\n!!7?JJYPGB#&&@@@@@@@@@@@@&P7~^^::::..^~~~~~~~~~~^^^^^~~!!!!!\r\n??JYPG#&&@@@@@@@@@@@@@@&#P?!~^::......:~~~~~~~^^^^^^~~!!!!!!\r\n5GB#&&@@@@@@@@@@@@@@&&BPYJJ!~^::.......:^^~~~~^^^^^^^^~~!!!!\r\n&&@@@@@@@@@@@@@@@&#G5Y?77??7^:^:::.........:::^^^^^^^^^^~!!!\r\n@@@@@@@@@@@@@@&#G5J?77!!777~:::..................:^^^^^~!!!!\r\n@@@@@@@@@@&&BPY?777!!!~!77~^:::..::.....   ....   ~^^^~!7!!!\r\n@@@@@@&&BPY?7!!!!!~~~~!!!~::^^:..::....            .:^~!7777\r\n@@&&BPY?77~~~~~~~^^^~~!!!:..::.......                .^!7777\r\nBPYJ7!!~~~~~~~~~~~~~~~!!!...........                  :77777\r\n7!!~~~^^^~~^^^^~~~^^~~!!!^    .  ...    ..  ...... ...:??777\r\n^^^^^::^^^^^^:^^^^^^~~~~!~.   ..        :. ...  ..   .:JJ???\r\n::::::.::::::::^^^^^~~~~~~. ............. ..... ..::^7Y55YJ?\r\n...........::.:::^^:::^:... ............... .. .:~JYYPGP555Y\r\n^^^::.............:        .::............... ...^7P#&&&#BGY\r\n~^^^^^:.......:..:. .::::^^^^:.:...................^YB#&BPY?\r\n~~~^^^~~^:.::::::::^~~~~~!~::...::...................:~?Y??7\r\n^^^^^^^^~~~~^^^^::^^~~~^^::.................:...........~?77\r\n:^^^~~^^^~~~~~~^^^^^^^^::................................:!!\r\n^^^^^^^~~~~~~~~~^^^^^:..........:..........................~\r\n~~~^^^^^^^^~~~~^^^^^:......................................^\r\n^^~~~~~~~^^^~~~~~^^^:.....................................:!\r\n~~^^^~~~~~^~~~~~~~~~^......................:::............~~\r\n^^^^~~^^^^^~~~~~~~~!^::.................................:~~~",
                    ChoisesId = new int[] { 19, 20, 21 },
                    ChoisesText = new string[]
                    {
                        "Купить новый",
                        "Принять таблетки от шизы",
                        "Превратиться в танк"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 18,
                    Text = "    Вы притворяетесь куском мяса и встаёте в Т позу\n" +
                    "и динозавр попадается в вашу ловушку и съедает вас..... Ну\n" +
                    "вас съели.... Вы умерли..... А, нет...  Он вас тупо\n" +
                    "проглотил лол, ну вы у него в желудке теперь....\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@GGBBGPY#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@#B&&BG5P@@@@@@@&##BGPPPPPPG#&@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@B&@&BPYG@@@&BGGGGGPP555YYJJJYP#@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@&B&@#BP55GGGBBBBBBGGGP55YYYJJJJ5B@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@&B&&#BGGGBB#####BBBGGPP55YYJJJJJY&@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@&G##BGGBB#&&&####BBGGPP55YYJJJJ?JB@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@&GPPPGB#&&&&&&###BBBGGP55YYJJJ???B@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@BPPG#&&&#G5Y??7777??JYY55YJJ???J#@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@GPB#GY7!!!77??JJ????????5Y???7?Y@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@&P5?77?JJYY5555555P5P55YJ5J??77?B\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@5!!!!!7J5PPPPP5YJ7!777?75J??7775\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@?:^~!7?JJJYYYYYYYJ?!~^^^5J??777J\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@B^^~~~!7??JYYJ?7777777!^^5J?7777Y\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@&7:~!7?JY5555PP5J?7!~~~~^~5??7777B\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@Y!????7777?7?JYYYJ?7~~~^^?5?7777Y@\r\n@@@@@@@@@@@@@@@@@@@@@@@@&J!J~!!~~7????7?77??YY7~~^~5???77?#@\r\n@@@@@@@@@@@@@@@@@@@@@@@#J77~~!~!7?JJJ5JYJJ???JYY^~5J?????B@@\r\n@@@@@@@@@@@@@@@@@@@@@&Y7?!~~~~!??J?YYYJY5YYYJJ55~YY?????G@@@\r\n@@@@@@@@@@@@@@@@@@&B5777~~~!!77?JJYYYYY5555JY57!YY????JB@@@@\r\n@@@@@@@@@@&#GP5YJ?77!!!~!!!77??JJYYY555YY5YYJ~75YJ???Y&@@@@@\r\n@@@@@@@G?J7!!!!!!!!~~!!!777???JJYYY55P55555!~J5JJJJJG@@@@@@@\r\n@@@@@B~:!?~^^~~~~~!!!!777??JJJJYYY555PP5YJ!75YJJJYP&@@@@@@@@\r\n@@@@G^:::J!~!!!!!7777?77?JJJJYYY555PPPJ!~7Y5YJJYP&@@@@@@@@@@\r\n@@@#~::::~Y7????7???JJJJYYYY555PP55J!~!?55YJJYP&@@@@@@@@@@@@\r\n@@@?^7!777J7^!????JYYYYYYYYYYYJ77777J555YJY5B&@@@@@@@@@@@@@@\r\n@@#!J^^~~!7J^:?55Y??77777!!7???JY5555YYY5G&@@@@@@@@@@@@@@@@@\r\n&#&5J7!!!7?Y^!BGPPPPPPPPPPPPPPP555YYPG#&@@@@@@@@@@@@@@@@@@@@\r\nG#&&B5?7??7!!P##&&&&&&&&&####BBB##&@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] {49},
                    ChoisesText = new string[]
                    {
                        "Забраться к нему в мозг"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 19,
                    Text =
                    "   Вы решаете купить новый, но вспоминаете, что вы\n" +
                    "нищий. После осознания этой мысли у вас начинается\n" +
                    "депрессия и вы ложитесь на кроватку.\n\n" +
                    "                                       .....................\r\n                                   ...................:::^^~\r\n                                  ......::.......:::^^~!7?JY\r\n                                .....::::::::::^^~!7??JY5PGG\r\n                       ...    .....:::^^^^~~~!!7??JY5PGGBB##\r\n    .              ..............::^^~~~!777??JJY5PPGBB####&\r\n.   .             ............:::^^~!77??JJYYY5PPGGGBB######\r\n.   .          ........:::::^^^~~!!7??JJJYY555PPGGBBB#######\r\n.   ..  ...........::::^^^^~~!!77??JYYY5555PPPPGGBBB########\r\n..  :..........::::^^^~~!~!!!7??JYY555PPPGGGGGGGBB########BB\r\n..  ^:...:::::^^^~~!~!~^.  ..:~?Y55PPPPPGGGGGGGGBB####BBBBGG\r\n   ....::^^^^^~~~!!!~.        .^J55PPPPPGGGGGGGGBBB##BBGGP5Y\r\n......::^~~~~~:...:^:.        .:J5PPPPPPPPPPPGGGBBBBGGPP5Y?7\r\n....:::^~~!~:     .:::^::    .:^JGPPPGGPPPP5PPPGGPPP55YJJ?7!\r\n....:::^!~:        ....:^^: :^~7^7GP5PPPPP5Y55555Y5YJ??77!~~\r\n  ...:~~~.      .........::::^^^^~J555P555YJJJJJJJ???7!!~!~~\r\n   ..~!~       ...  ....   ......:^7YJJYYYJ???77!!!!!!~~~!~~\r\n    ::^.    ........:.            .~J?77?J?777!!~~~~~~~~~~~~\r\n    .::      .......                :!7!!77!!~~~~~^^~~~~~~~~\r\n    .::     .......           .       :~~~~~~^^^^^^^^^^^~~^^\r\n   .:~:     .....            ~7:       .:^^^^^:^^^^^^^^^^^^^\r\n ..::~^                    ~55Y5Y?^       .~~~~~^^^^^^^^^^^^\r\n   .^^^~                  ^555PGGGBP~     .?YJ?77!!^^~~^^^^^\r\n     ..                 .^^:.......^~!:  .:~~!777~~^~~^^^^::\r\n                      .:::.:::......:^::. .::^^~!!7!~^:^^^^:\r\n       ......       . .:............      .:::::^^^^::::.:^:\r\n  .. .............. :. .........:.:::.....    ..::::::::::::\r\n .  ..... ..  ....  .:....... ............:..    ......:::..",
                    ChoisesId = new int[] { 22, 23, 24 },
                    ChoisesText = new string[]
                    {
                        "Плакать в падушку",
                        "Стать весёлым",
                        "Пайтон - памойка"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 20,
                    Text =
                    "   Вы решаете прекратить всю эту дичь и наконец принят\n" +
                    "таблетки от шизы... Вдруг... Каким-то неведанным образом\n" +
                    "годзила пропадает... А за ним и тирекс, и обломки\n" +
                    "вертолёта, и город, и ваши друзья, да и вы сами....\n" +
                    "Оказывается, что вся ваша личность, вся ваша жизнь, всё\n" +
                    "ваше существование состояло из шизы... Вся ваша жизнь это\n" +
                    "ложь.... И вы..... Вы просто улитка....\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&&@@&&&&@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&#&@@@&&##&@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@&BBBG#@@@&#&@&&&&&@@@@&&##&&@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@&###G7^~!P####&&&&&&&@@@&&#B&&55B@@@@@@@@@@@@@@@@\r\n@@@@@@@@@&&Y77!YBBBBG!!?#&#BGB&@@&&&&#&@Y^~YBY55YG@@&&&@@@@@\r\n@@@@@@@@&B#GJYP#Y5PJ75Y?7J7!7JP#&#BGG#&7~YP5G5J7~YG5JY?Y#&&@\r\n@@@@@@@@&&#B5JYPJ!~7YPGB57:....:^77?PGY7YG5~^~~JGY5PJJ7J55G@\r\n@@@@@@@&&@&&&BG#&#GPBY!^^!7YGGY7^::^!7PBP5BGJ?JPG?^:^755YG@@\r\n@@@@@@&##BB&@&&&&#Y~7GPPG#G7~~~JPGBG5J~^!5##&&&&&#B5Y555G@@@\r\n@@@@&@@@&@@@@@&####&@@&#GGGJ?JP#Y7YYJPBG5JJ^?BGP#@@@@@&@@@@@\r\n@@@&BGGG#@@&&&&#&@@@@@@&BY!~77!JJ!~!?PJ!5YY!^^~?&&&&@@@@@@@@\r\n@@&&&##&&@&BGPGB&@@@@#G#BPY5!:. :!7!!: :77J#&##&@@@@@@@@@@@@\r\n@@@@@@@@@@@@&&&B###B&B~~~~J##G5J?YGPYJ7?JYB@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@#JYYJ7B&BYJYYB#BG#P~^^7#&@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@&&P!~~JG##B#B7~777B@&##&@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@&&&&PJPP5J#BY??G&@@@@@@@@&5GPGGGPPPP#&&&@@@@@\r\n@@@@@@@@@@@@@@@@@&&#Y!~!P&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@&##BB#&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] {43},
                    ChoisesText = new string[]
                    {
                        "Зайти в бар"
                    }
                }
            ); context.DbTimelimitedChoises.AddRange(
                new TimelimitedChoise
                {
                    Id = 21,
                    timeToChoose = 6000,
                    Text =
                    "   Вы в ЯРОСТИ, годзила убил вашего тиммейта у вас на\n" +
                    "глазах и уже целит лучём на вас!!! И ВДРУГ.... БЖЩЩЩЩЩЩ\n" +
                    "ОГРОМНЫЙ СИНИЙ ЛУЧЬ СУПЕР БОЛЬШОЙ ЭНЕРГИИ!!!! Ну а чё вам?\n" +
                    "Вы быстренько превращаетсь В ЛЕГЕНДАРНЫЙ ТАНК Т34!!!!\n" +
                    "ПОХОДУ ГОДЗИЛА ЛОХ И НЕ ШАРИТ ЗА БАЗУ, ПОЭТОМУ ВЫ\n" +
                    "БЫСТРЕНЬКО ОТРАЖАЕТЕ ЕГО ЛУЧЬ!!!! ВСЁ ЭТО БЛАГОДАРЯ\n" +
                    "УНИКАЛЬНОЙ ЗАЩИЩОННОСТИ И ЛЕГЕНДАРНОСТИ ТАНКА Т34!!!!\n" +
                    "ХОЧЕШЬ ТАКЖЕ!?!?!?!?!? ПЕРЕХОДИ ПО ССЫЛКЕ В ОПИСАНИИ И\n" +
                    "ПОЛУЧИ ЛЕГЕНДАРНЫЙ Т34 И НЕДЕЛЮ ПРЕМА В ПОДАРОК!!!!! Что,\n" +
                    "према недостаточно? Ну хорошо.... хорошо... уговорил....\n" +
                    "только тебе в подарок легендарный СУ-69!!!! УСПЕЙ\n" +
                    "ЗАРЕГЕСТРИРОВАТЬСЯ СЕЙЧАС!!! ВРЕМЯ ОГРАНИЧЕНО!!!!" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@&B#&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@7 :7?5GB&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@G7^:::::7YB&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@&&B5?7?7~~7?J5G#&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@&B?^:^~!7JG#&@@@@@&@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&#BY!~~~~!?YGB&#@@@@@@@@@@@@&&&&@@@@&YJ??PB\r\n@@@@@@@@@@&&@&&###BGPYYJJ??7~~^~7JPB#&&@&&BBP5Y55P#555JY555Y\r\n@@@@@@@@@@&&&B5JJ???J777J?JYJJJJ7!^^~!J5Y?!:::~7!^JJ7JPGGBBG\r\n@@@@@@@@@@&#B5YJ??77777!777?7?JYJY5YY7:::^^^^~?JJJ5P5Y5PJPGG\r\n@@@@@@@@@@&#G5J??77?777!77?77?7J75GP57:^.    .^:^?JYJJYY5555\r\n5PB&&&&###BPJ?777!!!!77~!!!!!~!!?Y!^^^~~^::::::^^^^^:^77??J?\r\nJJ77Y?7JJJ?!!!!~!!!~^^~^~~!~.::!P5Y5PPYJYYY55555P5Y7:!Y5PGGG\r\n????5Y:~~!~!777~!~!~!!~~!J5Y7!77JJYYYYJJJYYYYYYYYYYJJYYYP5Y5\r\nYJ????!?JJ?7?JJJJYYYYYJJJ7?7Y5PPP5YYY55PPPPP5?!JY55555P55PP5\r\nYJ?JJ?7???7!J5555Y5555?Y?^~7?J7~^:.::^~7?Y55Y~!JYYYY555555Y5\r\n~^~~~~!~~!~~JJJJJ?????7!^::::.............:::^^!^^::::::.::^\r\n.    :^....:^::........   ..........................      ..\r\n     ~!^::::::........      ................................\r\n..:  .::^!?!~~^.  ..                               ..... ...\r\n::^^^^^^7??YY5PPJ:                                  .       \r\n&&&&&&&&&&#######P!.                                        \r\n#BBBBBBB##BBBGPGGPP5JJYYJ???7??77777!!~~~~~^^^^:::::.....:..\r\nBBBB##############BB###########BB##BGBBBBBGGBBBBBBGGGGPPPP55\r\nBBBBBBBBBBBBBB########B#######B###BBB###BBBBGGGGGGPGPGPPPPPP\r\nGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPGGGPPPPPPPPPPPPPPPPPPPPPPPP",
                    ChoisesId = new int[] {44, 45},
                    ChoisesText = new string[]
                    {
                        "Зарегаться как можно скорее!"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 22,
                    Text =
                    "   Вы начинаете рыдать в подушку, но вдруг чувствуете\n" +
                    "что-то твёрдое под ней. Там оказывается микрофон, который\n" +
                    "записывал как вы плакали и кошелёк с фри хандрид бакс. У\n" +
                    "вас больше нет депрессии и вы не бедный. Что вы будете делать?\n\n" +
                    "::::::::::::^^~~~~~!!!!!~~~~~~~!!~~~~~~~~!7?77!!!7!~~~~~~~~~\r\n::::::::::^^^^^^^^~~~~^^^~~~^^~~~~~~~!~~~~~!!!!7!!!!~~~~~~~~\r\n::::::::^^~~~^^^^^^^^:::^^^~~~~~^^~~~~~~~~~~~!!77777!!!!~~!!\r\n:::::::^^^^~~~~^^^^^^^:::^^^~7!!~~~~~~~!!!!!!!!!!7777777!!!!\r\n:::::::^^^^^^~~!~~^^^^^^^^:!B&B5Y?7!~~~~!!777!!!!!!!7777777!\r\n::::::^^^^^^^^~~~~~~^^^^^^7#&@&BBBGP7^::^~!77777!!!!!7777?77\r\n:::^^^^^^^^^^^^^~~~~~~~~~?B#BBBGGBY~...^7~^!!777777!!!!77777\r\n::^^^^^^~~~~~~!!7777!!!~J##P555Y7^...:^!J~^!~^^^:!!!77777777\r\n::^^^^^~7?J5PGGBBBG55Y77P&&G5?~:...:~~~:........^!J7!??777!!\r\n^::^^^:!?YG#BB577!^:75PGB##G~:...:~~~~^::....::^^!???JJ?????\r\n^^^^^::7J5G#G7: .:!5GB##GY~^:^:.~??~^::::::^^^~!!7777??JJJJ?\r\n~~~~::^7J5PPJ~:7YG#&&&GY7!^~~::^^^^::^^^:::^^~~~~~!77?7??JJ?\r\n~~!^:^~7???7!?JPB&&&&#5JJ?!77!^.:^~^^^^^~~^^^^^^~~~~!!?J7?J?\r\n~~~::~!777?JY5PB#B#BY~7?!7????7!^::^~^:.?B5^^^^^~~~~~~777?JJ\r\n~~::^!!7?YYPGB#BYY#7??7!77??JJ?77!~::: .7B&7^~~~~~~!7!77???J\r\n~::~!77?YPGGBGJ!!Y!J?!77!7?JJ777??7!^  .~YBG~^~~~!!7!7??????\r\n:^!!7?JYPGBGY!!?7: :~!77???????JJJJ?7~..^!YB?^^~!!!7?????7??\r\n~!77J5PGGG5J7???!^:..:^7??????JJJYYJJ7. :^7GB!!!^~PGJ???????\r\n7?YPGBBG5J77?7!~~~!~:...^!?????JJJJJJ!. .^~JB5^..^?GB???????\r\nYPGBBG5Y?7!!!!~~~!!7!~^...:!?J???JJ??^  .^!YG#G::~?G#B??????\r\nPGPP5Y?7~^^^~~~~~!77777!^:..:~7????7!.  :~7YGB##GGB#&&B?????\r\n5YYJ?!!~~^^^^^~~!!!777777!~:...^7??!^  .^!JYPB##&&&&&&P7????\r\nYY?~^^~~~~~^^^^~~!!!77777777!^...^!!:  :~!?5PGB#&&&&&G?7????\r\nJ7^^^^^~~~~~~^^^^~~!!!77?77777!^. ...  :~~7J5G#&&&&&#J??????\r\n7!!!~^^^~~~~~~~^^^^~~!!!77777777!^.    :~~!?P#&&&&&#5JJJ????\r\n&&&&#BY7~~~~~~~~~^^^^~~~!!!7777777!^::.:~~~!YB&&&&&P????J???\r\n&&@@@@@@#?~~~^~~~~~^^^^~~~~!!7777777!^:^~~~~?G#&##B?7???????\r\n###&&&@@@&P~~~^^~~!!~~^^^~~~!!!77777~^^^~~~!?5B###5~!!7777??",
                    ChoisesId = new int[] { 25, 26, 27 },
                    ChoisesText = new string[]
                    {
                        "Побагатеньки развлекаться",
                        "Пойти в казик",
                        "Пойти купить мароженку"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 23,
                    Text =
                    "   Вы решаете, что типо ну ок, ну ладно и тупо\n" +
                    "становитесь весёлым (без колёс). Что теперь?\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&#@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&##@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&#&@@@@&&B&@@@@@@\r\n@@&B&@@@@@@&&@@@@@@@@@&GGPGB&@@@@@@@@@@@@@@&BB@@@@&##@@@@@@@\r\n@@&BG@@@@@&BB@@@@@@@&Y:... .:7G&@@@@@@@@@@@&#B#@@@&#&@@@@@@@\r\n@@@&GB@@@@&##@@@@@@&~:75P55J?7!~Y&@@@@@@@@@@&#B#&@&&&@@@@@@@\r\n@@@@#B&@@@&B#@@@@@@!^B&&&&&###BG~!&@@@@@@@@@@&&#&&&&&@&#&&@@\r\n@@@@@&B@@@&B&@@@@@@~J#BB#####BPGG^B@@@@@@@@@@@&&####&&&BP#&@\r\n@@@@@#G#&&&B&@@@@@&JBGYJ75#BY!~~5Y&@@@@@@@@@@@@&&&&&&GBPGGB@\r\n@@@@&G?5B##B@@@@@@#P##G5YG#G7J7JPG&@@@@@@@@@@@@&&&#B5PBPGGB@\r\n@&&&@&5Y5GBB&@@@@@&B#&&#####Y5BGBB&@@@@@@@@@@@@&&&#BPYG####@\r\n@&@&####BPPB#@@@@@@#GB5J555Y~~?PP#@@@@@@@@@@@@&G&&&&BGB&##&@\r\n@@&&####BGPPG&@@@@@@YYJ!!7?7!~!?Y&@@@@@@@@@@@BY?GB####&#B#@@\r\n@@&&&&&&&##GB@@@@@@@G^7P!^^~^?J^P&@@@@@@@@@&#BGBBB#&&&#G#@@@\r\n@@@&&&#&&#GY5&@@@@@@@J^?5YJJJ7^75B#&&&@@@&##&&&######BG#@@@@\r\n@@@&#&&##BP5PG#&&&&&@B5!~!!!^:7YP##&@@@@@#&&&&&&&##BB#&@@@@@\r\n@@@@#BBBBGGGBBBB#&&#&&&BP5P5GBB#&&&@@@@@@&&###BBG#&&@@@@@@@@\r\n@@@@@&GGGBBBGGBBB##&##&&&&@@&&@@@&@@@@@@@&###GP5G@@@@@@@@@@@\r\n@@@@@@@#GGGGGBBB###&&#&&&&&&&@@@@&@@@@@@&&&#BGPG&@@@@@@@@@@@\r\n@@@@@@@@#GGGGBGB&&&&@&#&@@@@@@@@@&@@@@@@@##&#&&@@@@@@@@@@@@@\r\n@@@@@@@@@&#BB##&@@@@@@&&@@@@@@@@@@@@@@@@@@#&&@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@&&@@@@@@@@@@@@@@@@@&&@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@&@@@@@@@@@@@@@&@@@@&@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@&@@@@@@@@@@@@&@@@@&&@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&@&@&&@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&@@&@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&@&@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 24,
                    Text =
                    "   В момент отчаяния вы вспоминаете, что помимо вас есть\n" +
                    "ещё более ненависная вещь чем вы. Вы вспоминаете какой\n" +
                    "пайтон медленный, как в нём нет точек с запятой, какой он\n" +
                    "уродлиный и ВЫСОКОУРОВНЕВЫЙ. Вы вспоминаете об его ООП, а\n" +
                    "точнее о том насколько оно уродливо. Вы вспоминаете, что\n" +
                    "все пользователи пайтона тупо накачивают тыщу либ и ничего\n" +
                    "не делают, ну потому что это типо пайтон, он для лохов, чё\n" +
                    "там делать, в общем да, после этого осознания вам явно\n" +
                    "становится лучше, что теперь?\n\n" +
                    "&&&&&&&&&&&&&&&&&&&&&&######################################\r\n############################################################\r\n#####################GP5YYJJJJJJJJYY5PB#####################\r\n##################BJ7!77!!!!!!!!!!!!!!!?P###################\r\n&&#####&&#########7!7&@@&J!!!!!!!!!!!!!!~J##################\r\n&&&&&##&&########B7!7&@@@J!!!!!!!!!!!!!!!!B#################\r\n&&#&&##&&########B!!!!??!!!!!!!!!!!!!!!!!!B#################\r\n&&#####&&&&&&&&&&#PPP5555P55P57!!!!!!!!!!!B&################\r\n&########G5YJJJJJJJJJJJJJJJJJJ!!!!!!!!!!!!B#################\r\n&######577!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!B&################\r\n#&&&&#J!777777777777!!!!!!!!!!!!!!!!!!!!!!#&################\r\n##&&#5!7777777777777!!!!!!!!!!!!!!!!!!!!~?##################\r\n##&&#?7777777777777!!!!!!!!!!!!!!!!!!!!!Y#&#################\r\n####B7777777777777!!7JYY555555YYYYYY55G#&&##################\r\n####B77777777777!7YG#&&&&&&&&&&&&&&&&&&&####################\r\n#####?77777777777G&&&&&&&&&&&&&&&&&&&&&&####################\r\n#####P!77777777!P#&&&&&&&&&&&&&&&&&&&&&&####################\r\n######J!7777777!G&&&&&&&&&&&&&&&&&&&&&&&####################\r\n#######57!!!!!!!G&&&&&&&&&&&&&&&&&&&&#######################\r\n#########G5YYYYYB&&&&&&&&&&&&&&&&&&&&&######################\r\n#################&&&&&&&&&&&&&&&&&&&##&&####################\r\n#################&&&&&&&&&&&&&&&&&&&&&&#####################\r\n#################&&&&&&&&&&&&&&&&&&@@@@&####################\r\n##################&&&&&&&&&&&&&&&&&@@@@&####################\r\n###################&&&&&&&&&&&&&&&&&&&######################\r\n######################&&&&&&&&&&&&&&########################\r\n############################################################\r\n############################################################",
                    ChoisesId = new int[] { 34, 35 },
                    ChoisesText = new string[]
                    {
                        "С++ - имба",
                        "За JS меня булили в детстве"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 25,
                    Text =
                    "   Вы пошли в озон и заказали там себе телевизор за 5\n" +
                    "миллионов, тапочки за 13 миллионов, носки за 300Кб,\n" +
                    "зубная паста 5Тб, 13Гб пива, 17см нагетсы в спаре. У вас\n" +
                    "кончились деньги... У вас кончился интернет... У вас\n" +
                    "кончились друзья... У вас кончился шампунь... Вам больше\n" +
                    "нечего делать... Вот только если бы вы могли всё изменить...\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@&#B@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@&!!!~5#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@&J^.:!!!7JP#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@Y7J~..^!77!!7J5B#&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@B^7J?J^:^!!!7777!!!!?5G#@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@^^!77!~!!!777777?7????7!!7JP&@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@#55YYY?~!~~~!????77??7!7???~~!7B@@@@@@@@@@@@@@@@@@\r\n@@@@@&BB&&&&#B#&&BPY!~^~!!77?7!~77!!^~7!?B&&&&@@@@@@@@@@@@@@\r\n@@&&@#5#&&#BB#&&&BY?~~!^^!!~~~!!~~^~!JP#&@@&@@&&&@@@@@@@@@@@\r\n@@&&##&&##&@@&&&BJ7!!7J?~^~!!!~^^^~!JB##&#YG#&@@@&&@@@@@@@@@\r\n&#&#&&@@&&@@@@&&5!J?777JJ?!!?~^^!7~!J?~~??7~~5&@@@&#@@@@@@@@\r\n#G&&&&@@&@@@@@&&5::^JB#&&&&J?:^~!!^7YJ~~?7?!~~B@@@@&B@@@@@@@\r\n#&&&&&@@&@@@@@&&#?~P&&&BJ7!^^^~!^^^~JJ!!!^7J~!7&@@@@&#&@@@@@\r\n&&&&&&&@&@@@@&&&&#B&&#BGPYJ55J!77!^^?J7~~~7J7!^?#&@@@&#&@@@@\r\n&&&&&&&@@@@@&&&&&&#&&B&@@@@@@@&5?7!!!!~~~~!?J7~:7B&&&&&&&&&@\r\n&&&#&&&@@@&&&&&&&&#BB&@@@@@@@@@J??:.::^~~^^77?!!^7PGB#&@@@&&\r\n#&#&#&&&@&&&&&&&&#GG@@@@@@@@@@@&#&P....::^:~^^~7J5PPG#&&&&&&\r\n##&&#&&&@&&&&&###GB@@@@@@@@@@@@@@@@B:::::^^~:^75GBGPG###&&B5\r\n@##&&#&&&&&##BGPP&@@@@@@@@@@@@@@@@@@G.::::^:Y&@@&#G55PB#BPYY\r\n@&#&&&&#GP555555JP@@@@@@@@@@@@@@@@@@@J..:^!G@@@@@@@@&GP5J?JJ\r\n@@&#BGGPPPPPP555Y!P@@@@@@@@@@@@@@@@@@&::?B@@@@@@@@@@@@5~??7!\r\n@@G55GG5GGGPPP5P5J?#@@@@@@@@@@@@@@@@@@G&@@@@@@@@@@@@@@@J~!~!\r\n@5Y5GG55GPGPYYP5YY??P@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&57~\r\n@BJYP55GGGGG5GGGGPYJJB@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&B\r\n@@5YYPGGPGP5PGPGP5PYJ?&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { 28, 29 },
                    ChoisesText = new string[]
                    {
                        "Да",
                        "Нет"
                    }
                }
            ); context.DbRandomChoises.AddRange(
                new RandomChoise
                {
                    Id = 26,
                    Text =
                    "   Вы залетаете в казик и идёте крутить зевса на все свои\n" +
                    "деньги и...\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@&&B#@&@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@&&P#BJY#GB#&@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@BBPY?JYGG5YJJPBG@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@#J?JJP#&&GJ?JJJG@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@BPPYG##GG5P7!5##&@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@&#&&PY&&BBP^77!YBYG&@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@&B&&B5JB#BGJ5G5G?5PPYB&@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@&&G#&P5GGBBBP55GB??GBYG&&@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&@&#BBGB#BB&@@@&GG5YJ7?5BBB@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&@####&&B#&&@@@&GPPJ!~~?5YG&&&&@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&&&BBP5G#&@@@&#&&#GBG5Y5B&&&##B#&&@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@&&###G5??GBP5PJJYJ5PG#&&BGPG&@@@@@@@@@\r\n@@@@@@@@@@@@@@&&@@@@@@@@@&GY!^~~^^~7^^~?5P5JYB&&#B??YB@@@@@@\r\n@@@@@@@@@@&@@&G5P&@@@@@@@@&&#55!!JYJPY?YJ7?YPB#&&&?:?B@@@@@@\r\n@@@@@@@@#PB&GP5Y?5&@&&&&##BGGJJYG!^?JJ5!??!7Y5BBG&&GG@@@@@@@\r\n@@@@@@@#5#&P!7YY?!JBGGBGGGGBBBGG5??~:~J7?!~!?J?7!JBB#@@@@@@@\r\n@@@@@@&@B?!!??~!7~^YGB#######GBGY775J?7JBB!^^^~!:^^77#@@@@@@\r\nJ?7~J#&G7?:^7!:.^^~?JY7P!!JJ7!??~:7GBG!!J?J!G.^^^7!~:7?Y~!JJ\r\n~^~!?5G^J@5.7!~~~@#~7?~7J:@#^~G@7^#&BJ^5##:G@Y!@5..~@&.!7~^~\r\n!^^~~?J.B&&:&@@@:@P.PJYPY:@G^:P@~5@#G:B.^@?Y@@:@?.^BBG.~~:~7\r\nP5G#GGY^B^@^#@@&:@#:7^?PY:@5^:P@~G&&?7#.~@B~@@:@J B.5G:&#P55\r\n@@@@@@!G~.@5?@@&:@&^J:P#Y:@Y~:P@~5&&~P?~!@&^@@:&JG!:YG!@@@@@\r\n@@@@@#^B~~B&:@@@:@#.GPPY!:@J!^G@~Y@&:B:B:#@:&&:@@YJP?#~@@@@@\r\n@@@@#!5J!~P@!Y&Y:@&^77^~^^@Y^:#@7^577&:J:&@^B&:@@#@7Y@P@@@@@\r\n@@@@~55?JJ5JB~?!JYJ?7?~5?75?.~J?!.:.?Y~ :JJ:5@&&@@&~#&&@@@@@\r\n@@@@B?!#@@@B??B@&P?JJJY5PPP5B&G!!J??????7~~7P@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@&PJ7:!JY!JY5??GG7!!???~!7!!P5Y&@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { 30, 31, 32 },
                    ChoisesText = new string[]
                    { }
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 27,
                    EndId = 2,
                    Text =
                    "   Вы решаете просто пойти купить мороженку, ведь в конце\n" +
                    "концов деньги не главное, а главное - друзья, которые нас\n" +
                    "окружают. Мир прекрасен такой как есть и вы прекрасны и без\n" +
                    "денег и в этом нет ничего плохого. С осознанием этих мыслей\n" +
                    "вы отправляетесь в закат на единороге стреляя лазеры из\n" +
                    "глаз. КОНЕЦ\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&#BP5YJJJ??JJJY5PG#&@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@&B5?7!!!7??JJYYYYYYYJJ??77?YG#@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@#PJ7!!7JY55PPGBB###########BGPY?77YG&\r\n@@@@@@@@@@@@@@@@@@@@&GY??JY555PGB#&&&&#BGPP55555PPGB###BG5?7\r\n@@@@@@@@@@@@@@@@@@#PYJYPGGGGB#&&&#G5J???JY5PPPGGPPP55YY5G##B\r\n@@@@@@@@@@@@@@@@BYJY5GBBB#&&@&#PJ?7?YPB###BGP55YYY55PGGGP55P\r\n@@@@@@@@@@@@@@#J7?YG####&@@&#PYJJ5G###GY?!~~~~~~~~~~~~~!?5GG\r\n@@@@@@@@@@@@@5!!7YGBB#&@@@&BPPPB#&&BY!~^~~!!!7?J5PPPP5Y?7~~!\r\n@@@@@@@@@@@&J~!!YPGG&@@@&#BBB#&&&BY7!!!!7!75B&@@@@@@@@@@@&GJ\r\n@@@@@@@@@@&7!!7YP5P&@@@&B##&@@@&PJ?????7YB@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@?!!!YP5P#&&&BPGB&@@@#P55YYJJYB@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@J~!YBG5P#&&&PY5P#&&@B5PP55YYP&&&&@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@G!!!P#P5B&&&G7??G&&&G?JYYJYYP&&&&&&&&&@@@@@@@@@@@@@@\r\n@@@@@&&&7!!7555P&&&#???Y###G!!777??Y#&&&&&&&&&&&&&&@@@@@@@@@\r\n@@@&&&&G!!!?P55B&&&57??G###7~~~7777B&&&&&&&&&&&&&&&&&&&&@@@@\r\n&&&&&&&Y!!!YPPP&&&&J??J###G~~^~777Y#&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&J!!!5G#G&&&#??7Y###Y~77JJ?7P#&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&#?!!!5PPP&&&B???5####&@@@@@&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&#?!!!555P&@&&&&&&&&@@@@@@@@@@@@@&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&#Y~!!5GGG&&@@@@@@@@@@@@@@@@@@@@@@@&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&#G?G&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 28,
                    EndId = 3,
                    Text =
                    "   Вы решаете изменить свою жизнь и телепортируетесь назад\n" +
                    "во времени. Но теперь вы уже другой человек и знаете, чего\n" +
                    "действительно хотите. СССР в ваших руках не развалится. КОНЕЦ\n\n" +
                    "::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\r\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\r\n::::::::::::::::::::::::::::^77^::::::::::::::::::::::::::::\r\n::::::::::::::::::::::::::::7557::::::::::::::::::::::::::::\r\n::::::::::::::::::::::~7??77Y77J77??!~::::::::::::::::::::::\r\n::::::::::::::::::::::^!?YJ7^::~7JY?~^::::::::::::::::::::::\r\n:::::::::::::::::::::::::^?J~~~~JJ::::::::::::::::::::::::::\r\n:::::::::::::::::::::::::!55???J55~:::::::::::::::::::::::::\r\n:::::::::::::::::::::::::7?!^::^!?7:::::::::::::::::::::::::\r\n:::::::::::::::::::::^^:::::::^^^:::::::::::::::::::::::::::\r\n::::::::::::::::::::::::::::::^~7??!^:::::::::::::::::::::::\r\n:::::::::::::::::::::::::^^^:::::~?5PJ~::::::^::::::::::::::\r\n::::::::::::::::::::::^75GGPP5J!^::~JBBJ^:::::::::::::::::::\r\n::::::::::::::::::::^?P##&&##P?^::::^7B#G7::::::::::::::::::\r\n::::::::::::::::::~?G###&##P7^::::::^^?B#B7^::::::::::::::::\r\n::::::::::::::::^?G###&####G?~::::::::~5##G~::::::::::::::::\r\n::::::::::::::::^!5###BY!?G##GJ~::::::^?##BJ^:::::::::::::::\r\n::::::::::::::::::^!JJ~:::^?G##BY!^:::^J###P^:::::::::::::::\r\n::::::::::::::::::::::::::::^?P#&B57^^7G###5^:::::::::::::::\r\n:::::::::::::::::::::^^~~:::::^7PB##G5G###G7::::::::::::::::\r\n:::::::::::::::::::^7PGBB5?!~^^^!YB##&###B7:::::::::::::::::\r\n:::::::::::::::::~7P##GYPB##BGGGBB#&#&&&#G!^::::::::::::::::\r\n::::::::::::::~?PB#B5~^:^!J5GB#####BGPP#&##P7^::::::::::::::\r\n:::::::::::::7G###B?::::::::^~~~!!~~^:^!5B&&#G!:::::::::::::\r\n::::::::::::^?GBGJ!:::::::::::::::::::::^!5GG5~:::::::::::::\r\n:::::::::::::^^^^::::::::::::::::::::::::::^^^::::::::::::::\r\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\r\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 29,
                    EndId = 4,
                    Text =
                    "   Вы решаете ничего не менять и оставить всё как есть. Вы\n" +
                    "не просто какой-то нормис, вы - терпила, поэтому ну\n" +
                    "потерпите бедность, за-то научитесь экономить и с пола есть\n" +
                    "(как я). КОНЕЦ\n\n" +
                    "#B#&&&&#BBBBBGPPG&&#G5#&&#GJ#&&&&&&##&B?!^^^^^::.^B#B@@@@@@@\r\n#BGBBGBGGBGPPGP5PGG#BGBB#&#B&#5???7??7^:::^^~~^^^:~GPB@@@@@@\r\n##55PPGP5B#PPGPPPGPPPPP55#&&&#GY?JJ!~:...::::::::::~5B&@@@@@\r\n#BYPGB##BB#GGGGBGPGPPPPP5BB5G#B#&#?:::.....:.::.....^5&&@@@&\r\nGP55G#BBBGBGGPGGPPBGGB&&&&#B#&#&#~...................^##&&#B\r\nJ55P555PPPBYYYP5PPGBB&&&@&&G?#&P!................    .55PGGG\r\nY55YJY5BBG#G5P5PPGG5Y5?~P#G5.!P!.    .::::.:.......   ?5PP55\r\nP5GPJJJG##BGYJYY5GG5JJY?PPPG~^^7^7?J5GGPJ777Y5Y?~:  .JGYPPGP\r\n5PJ777?JJ?PPJYJYYPB#B###G?!J..:~J55YBBGG5J?5GY7!!~^ !@G!G##B\r\nB&B??YYYBP&#~YPPGGGBBBBP5?:::.~.!?JYGBBGPP##P7~~7!J?JBP?YYY5\r\nB#&PPP5?&###Y55PPPPP555YJ7!.::^.:?5J5P?~!G#BJ!Y?7755!7P5YYJ?\r\n?!7YBB5JJ7JYJJY5555YJ??7?7~:.^. .7Y55!~!^:!~^^7!~~^7YYPG5PPP\r\n5!^JB5Y5777~?JJJ?JYYJ7~~!!~^...  ^5GGY77^:...^~^7~:~J777JPPG\r\n55PG#JYYYJ??7!!?77YJ7!~~^^~~^::.. ^Y##G5?7!~!7?7JJ?JJ???YYYY\r\n?5GGBG5~^:::..^!~J?:.:~~^:~~!:^^^.  :~7!?JP###B##PB##&&&####\r\n##&#!~.    .:~!7Y7:. .:^~::~~^.:!?~    .BBJPBBGGPPGBB#BBGGBG\r\n##&#^. .:~7J55Y?^... .:^:..:::~G@@&GY!. ::~PBBGPP5PGG######B\r\n&##G. :!JYYJ?!^...    :^:..:?B@@#P5PGBB!  .:JJ5PP5YJ.!P&####\r\nBBB!:^^::.....:~7~^!?55??!J&@@&#PYJ?PG5?:... ^?J?!~^.:.7&##B\r\n&&5!J?!~^!5PY?J5Y5BBBG77~:B&&&#GY?YPG5?..:..:  . ....:.^#&##\r\n@&?!~~^!5GPPPPPP5Y5JYJ~^^.5GG5YJYGG5!7:.... ..     .....7&&&\r\nP:.::~5GPY?7?JJ??77~~~!:^..:~!~^~7?!..::::    .      ....B@&\r\n::!^7PPY7~~!!??!~^:^^~!^..        ....::::...     .. . .:GBP\r\nJ?7^7J7::^~~~:....:~!7~. ........ ..........:.  ....  ..^#BP\r\n7~^^!J:...:::.....:::.     .^....  .........:.  ..    . ^&&#\r\n!:.^!:.....:.......         ....   ...........         :B&&#\r\n~:.:..........   !5?^       .... . ...........      .:?BBBBB\r\n&5~ ....          .~7.  . .  ... . ......... ~7:..:7PGGPGGGG",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 30,
                    EndId = 5,
                    Text =
                    "   Барабаны крутятся... крутятся... и вдруг... Вам выпадает\n" +
                    "1000x!!! Вы получаете власть, которая и не снилась вашему\n" +
                    "отцу, вы покупаете дом, квартиру, остров на мальдивах, о\n" +
                    "том как вы развлекаетесь ходят слухи по всему миру, о вас\n" +
                    "преподают в школах, как чела, который победил казик, вы тот\n" +
                    "самый 0,0000000000000001%, которые дошли до большого\n" +
                    "выйгрыша. Это успех, это победа, это... это... этого\n" +
                    "недостаточно, понимаете вы........... Вы продаёте свою\n" +
                    "золотую яхту, свой эмпайр стэйт билдинг, свой остров на\n" +
                    "мальдивах, свою семью, своих друзей, свою страну, свой\n" +
                    "материк в европе, свой спутник земли..... И всё, ради того,\n" +
                    "чтобы ещё раз попытать удачу ещё раз, ведь вы точно знаете,\n" +
                    "что вы тот самый, один единственный 0,0000000000000001%,\n" +
                    "который прошёл казино, и вы просто хотите перепройти его\n" +
                    "ради атчивки в стиме. КОНЕЦ\n\n" +
                    "&&&&P55#5!!YPB@@@@@@@@@#5JB&@@@@@@@&&&&&&&&#&&&&&&B&&&&&&&&&\r\n@@@@@G#BPB&&&#&@@&@@@@@&#@&P?7?!~J#&&&&&&&#&&&&&BPP&&#GBB&##\r\n@@@@@&@@@@@@@&B#@##@@@&&@#^.?5J~. .#G#&&&&#&&&#55B##Y~PBGGGB\r\n@@@@&BBGYY?JB#B&##7G&BB&@J.5&#5?^^ 7GGJ&&#&&&&?~5##G7PGGBG@@\r\n&@&BPJYYJJYJ?G&&BY??55&#BJ~5~.!~..:G#?5#&G##B&B5G&BP&G5B#&@@\r\n5Y55PBGGB##GPJYGB!J5#BB5B#B&B57:^~J@@#5PGJ5&#&G&@@&B5P##BG@@\r\nB##&@#?7~5BBGPY7J5GB#&#B#PJB5J^.^7G##B5GY7PB#&&&&&&BGG#@&G@@\r\nG#&@@@#B#&#B7~^::^P@@G#@&J7&P!::~PBBB##GJP##BPJ5G5PPG7?G@@@&\r\n~??G&@@@&B57^^7YGBB&B77P?~7@#J.:!^:7YG#B#@#&@BPPGG&&JG7^G@&P\r\n57:^5@@#Y?Y5B&&&#!~!~~~~!~!GB7 ~!!:    ..:?&&B5B&@@@&7Y~JP5G\r\n#P^^?555G&@&B&G7^::~^::::::~~: ^?!!!:      ^PG#@@G!Y@&YPPP##\r\n#G555B##5JPBGGP  ..:.......::.:.~JYY.         :J&&GB&&#Y5P&#\r\n5GB&@@GG5?G&@&G5  .........      :.             7&&BY?JPG5B&\r\n7Y@@@&&###&@@@B#G^..........    .         :   :~J5575Y~!?7?P\r\n .&@&B#&&&&&&GPP5GG:........   .         5@BYJ?7Y~?JGG7#G!Y&\r\n7Y&&&@@@@@&##BBP75P7...........         Y@GPB#PPY5555YP#PBGG\r\nJ&&#@@@@&@@@BB@GYY!!.::::......        ^GP?J?YGG55Y?7YY5BPYG\r\n##G#@&BBPG&##@#5GGP5^:::::....         J&GY5YJPPPYJY555YYG&@\r\n55PB#5?JP#B#@GPGGG5P?^^..:..:.        .7P5GGBPGGYYYPGP#J7JB@\r\nBBBP7!!?GGG@#Y7?!J55~::::::..          5GGGPYYJBBGP5#@@@BJ!7\r\n&&&GYYYP5P&5YY7?YJJJ~~^::..   ::       JG5Y5B&BY#GG&@@P5&@#G\r\n@&GP5G&BB@5?YPGPPG&P^:...    :~.       !&P?P&BYJG&&@@@&#BGGP\r\n@&BBG&B#@#GB#G5G#G&P:::... .:^:        :&&&5G#YP##B#&@@BBBPJ\r\n@&BB&##@&#&BY5PGB&&7:::...:::.         :#&&@BG5B&#B#&&GBG5GJ\r\n&@@&#&@&&&J?GPG#BPJ:::..               7@&&&@Y7YG&#B#GGB~!JY\r\nBG####G&B!Y#GG&@PYY~:::..             .G&@@&#&55##BBGPP??!B5\r\nJPBGP5G5^5#P#&@@@@#^:..               5GG&@@&&&#P##&##&&##BB\r\n5P5JJ5J^7??JYY5G#@&^..               :##PPB@@@&#&BB#&&&&&&&&",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 31,
                    EndId = 6,
                    Text =
                    "   Барабаны крутятся... крутятся... и вдруг... Вы отдаёте\n" +
                    "все свои деньги деду..... Вы пытаетесь ещё раз и вроде даже\n" +
                    "чуть-чуть окупаетесь, но снова теряете всё.... Вы берёте в\n" +
                    "кредит и снова всё проигрываете.... Берёте в кредит ещё и\n" +
                    "ещё и всё больше и больше проигрываете... Для того? чтобы\n" +
                    "уплачивать долги вы начинаете рубить дерево и продавать\n" +
                    "свои органы... Вы начинаете охотится на демонов, у вас\n" +
                    "появляется работа по охоте на них, но ваши долги только\n" +
                    "растут..... Вы понимаете, что идти больше некуда... Как\n" +
                    "вдруг в метро вас встречает человек, который предлагает\n" +
                    "сыграть в игру. У вас сначала не получается, но потом вы\n" +
                    "выигрываете и он даёт вам деньги и номер телефона... У вас\n" +
                    "больше ничего не остаётся кроме как принять предложение и\n" +
                    "сыграть в вашу последнюю игру, победите ли вы или нет?\n" +
                    "Только дед знает ответ. КОНЕЦ\n\n" +
                    "..........................:~7?JJ?!^:........................\r\n.......................^?GB#B#&&&&&#P!:.....................\r\n    .  ..............755P555YPGGBB#&&&BJ:.................  \r\nG?:         ..    .^JJ?7YJ7!!7??JYYPPPGBG7. .....  .      .!\r\nB&&P:            .!7!7?~:..........:~J5PP57             .?&&\r\n^?G&&!.         .!!~7~..~7YPPPPPPY7^. .!5Y5J           .P@#Y\r\n. .?BB^         ~~^~: .YJ~~!??JJ?7!~7.  :?!J?          P&P^ \r\n..  ^!?.       ^~:^. .^BY:^~!7!!!~^~G~   .~.7^        75?. :\r\n7.   ..^      .~:.: ..^#5:^~!!!!!~^!B!.   .:.!       .~:.  ^\r\nJ?.   .:      ^:.:  ..:BY.^^~~~~^^:~B~ .   . :.      ...  ..\r\n^^.   ..      ^...  ..:B5^~!!!!!!~^!G~ .   ...        :.  ..\r\n      .       ^..    ..7JJYJY5YYYJJ?7:.     ..        :.    \r\n      ..      :..    .....::::::.....       ..        ..    \r\n              ^..         ..                .:        .     \r\n              ^                             .^              \r\n       .      ^                             .:        .     \r\n       ...    .                             ..    ..::.     \r\n        .... ~^.                            .! ..::..       \r\n      ....   .^..                            ~:...          \r\n      ......::.                              :^::         . \r\n      .::~7?~:.                             .:~!7?^:..    . \r\n  ..:^!!!~^:...                            ...:::^~~!!~^:   \r\n.^~^^^^^:....                              .....::.::^~!J!: \r\n:.:..::::....                              .....:..:::...:::\r\n..:..:::.....                            . ....:...:::......\r\n  .:.::......                           .. ........:::.... .\r\n   ...:.......                         .. .......::::....   \r\n    ..:..  ..                          .. .........::. ..   ",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 32,
                    EndId = 7,
                    Text =
                    "   Барабаны крутятся... крутятся... и вдруг... Дед\n" +
                    "злится... И вдруг раз... И попадаете в какое-то странное\n" +
                    "место... Вам говорят, что дед на вас так сильно разозлился,\n" +
                    "что вас ударила молния и вы умерли. Перед вами ставят\n" +
                    "выбор, попасть в рай или выбрать способность и переродится\n" +
                    "в новом волшебном мире, с целью побороть величайшее зло\n" +
                    "ради исполнения желания. Не долго думая вы соглашаетесь и\n" +
                    "отправляетесь в этот необычный, таинственный и интересный\n" +
                    "мир. КОНЕЦ\n\n" +
                    "5555555555555555555555Y?7!!!!!!!!!~!7!!7!!!!7Y55PPPPPG&&&@@@\r\n555555555555555555555J?5!~~~~~~~~~~!JY!Y5YJ??7J55PPGB#&@@@&&\r\nP55555P5555555555555J~~!~~~~~!!!~~~~!~~!55P555PBGG#&&@@&&&&&\r\n&#BGPPGPPGP55555555J?7?JGP?PYPGYYJJPY!!!?5555G#&&&@@&&&&&&&#\r\n@@@@&BPP5PP5555555557?P7J!7J7!7!JJ!J7YJYJ555PGB&#&&#########\r\n&@@@@@&#BGPPP55YJ7!~^^^~~~!~!!~~~~~~^~^^~7?JYPGBB#BBB####BBB\r\n&&&&&&&&BG5?7!!!!7????JJPY7777P5YJ7777????77777?JYY5PGGGGGGG\r\n&&&#BP5J7!!!!!!!~~:::.!?YJ!:.:YP?Y:.....::^~!!777??JJJYY5PP5\r\nGBGYJ7!!~~~^^^^^^:..::JG?P#G??J?J7G?~~^:::.::^^^^^~~~!!7?JY5\r\nGGPPPP555YJ???777^:^~!&@J#@@&&Y???&&!~~~~~~~~!!77??JJYY5555P\r\nPPGGGGPPGGGGGGGGPY!!~~5@@@&&@@&BB&@#~~~~7JJ55PPPPPPGGGGBBGBB\r\n55PPPPPPPPPPPPGGGGPP!^!#@@BBBB#@@&B!^~^~?PBBBB#BBBB#&&&GJYPP\r\n55555PPPPPPPGGGGBB##J^^~JG#&&&&&#G!^^^:::G&&&&&&&&&&&G7!?YYY\r\nPPPPPP5PPPPPGGGGBBGPJ^~~^::~JYYY?7~~^:^!J#&&&&&&&&#G?~7JYYYY\r\nBBBB#BBGGBBBBBBBBGG5J^^~~~7Y777?~~~?PPGPY775####BG5J7?YYYYYY\r\n&&&&&&&&&&&&&&#&&##G~::^~~5@@&&P!!^?G7^:::::?BG5Y??J5GBBBBBB\r\n&&&&&&&&&&&&&&&&&&&!::::~!YG##G!~7^:::::::~JBBJJ5G#&&&&&&&&&\r\n&&&&&&&&&&&&&&&&@@G::::^YJ!~5Y~!?G^::::~JB&&GG#&&&&&&&&###BB\r\n@&&&@@@@@@@@@@@@@@5::::^B#!~?!~!P&57~JG##P7^^B@&@@@@&#BGGGGG\r\n&&&@@@@@@@@@@@@@@#7::::^#B!~?!~!YGY!7G5!^::::#@&&&@@&&######\r\n&&&&&@@@@@@@@@@@&~::::~PB?~~?!7J!^:^~?J~:::::J&@@&&&&&&&&###\r\n@@@@@@@@@@@@@@@@#^:^?PB5!~^~5B#P^~5##G##B5!^::B@@@@@@&&&&&&&\r\n@@@@@@@@@@@@@@@&?7PGPY5~^^?G&P!~~~7J!P#P?5BB57B@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@BGGJ!~PP~?B#&G!~^~!?!!B##!^~!Y#B&@@@@@@@@@@@@",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 33,
                    EndId = 8,
                    Text =
                    "   Вы решаете стать сектантом, чтобы сделать этот мир таким\n" +
                    "же весёлым как вы. Вы начинаете завлекать людей в секту\n" +
                    "фрути блади овердрайва, чтобы вместе построить новый мир\n" +
                    "(и запереть всех детей по подвалам). Через некоторое время\n" +
                    "ваша секта становится слишком популярна, а за ваши терракты\n" +
                    "и преступления вас начинают бояться, и все страны мира\n" +
                    "объединяются, чтобы остановить вас. Но вы используете\n" +
                    "ядерку и начинаете ядерную зему. Ну хайп а че. КОНЕЦ\n\n" +
                    "....................:::::::::::.::::::......................\r\n..............:::::::::::::::::::::::::::::::::::::.........\r\n.........:::::::::::::::::::::::::::::::::::::::::..........\r\n.....::::::::::::::::::::::::::::::::::::::::::::::::.......\r\n...:::::::::::::::::::::::::::::::::::::::::::::::::::::....\r\n:::::::::::::::::::^^^~~~~~~~~~~~~^^^:::::::::::::::::::::..\r\n::::::::::::::::^~~~~~!!77777777!!~~~~~^^:::::::::::::::::..\r\n:::::::::::::^~~~~~~!!!!!~~~~~~!!!!!~~~~~~^:::::::::::::::..\r\n:::::::::::^~~^^^^^^^^^^^^^^^^^^^^^^^^^^^^~~^:::::::::::::..\r\n:::::::::^~~^::::^^^^^^^^^^^^^^^^^^^^^^::::~~~:::::::::::::.\r\n::::::::^~~^..:^^^^^^^^^^^^^^^^^^^^^^^^^:...^~~^:::::::::::.\r\n:::::::^~~:...^^::::::::::::::::::::::::^^...:~~^::::::::::.\r\n:::::::~~^  .^::::::::::::::::::::::::::::^.  ^~~::::::::::.\r\n::::::^~~.  ::::::::::::::::::::::::::::::::  .~~^:::::::::.\r\n::::::~~~   ::::::::::::::::::::::::::::::::   ~~~::::::::::\r\n::::::~~~   ::::::::::::::::::::::::::::::::   ~~~::::::::::\r\n::::::^~~.  ::::::::::::::::::::::....:::::.  .~~^::::::::::\r\n:::::::~~^  .:::::::::::::::.............::   ^~~:::::::::::\r\n:::::::^~~:  .:::::::::....................  :~~^::::::::::.\r\n::::::::^~~:   .:::......................   :~~^:::::::::::.\r\n:::::::::^~~^.   ......................   .^~~^::::::::::::.\r\n:::::::::::~~~:.     ...............    .:~~^::::::::::::::.\r\n:::::::::::::~~~^..                . ..^~~^:::::::::::::::..\r\n:::::::::::::::^~~^...            ...^~~^:::::::::::::::::..\r\n::::::::::::::::::::::...........:::::::::::::::::::::::::..\r\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::..\r\n..:::::::::::::::::::::::::::::::::::::::::::::::.::::::::..\r\n...::::::::::::^^^^^^^^^^^^^^^^^^^^^^^^^:::::^:^^^::!777~:..\r\n.......::::::::^^^^^~^~~~~~^~~~~~~~^^^^^^::!:~~~!~:^?JYJ7:..\r\n............::::::::::::::::::::::::::::::::::::::.:^~!~^:..\r\n.....................::::::::::::::::::.....................",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 34,
                    Text =
                    "   Вы на секунду останавливаетесь и вспоминаете о том, что\n" +
                    "мир также состоит и из хороших вещей, к примеру C++.\n" +
                    "Шикарный, низкоуровневый, быстрый, с трушным ООП....\n" +
                    "Прекрасный язык, нету слов... Такой приближенный к\n" +
                    "машинному коду и удобно читаемый, просто хайп жесть.\n" +
                    "Так на нём ещё игрушки в анриле прогать одно удовольствие,\n" +
                    "так они и ещё 228337 фпсов дают с нулевой. Ну база, так ещё\n" +
                    "какая! Шедевро вещь, респект.\n\n" +
                    "                         .^?Y55Y?^.                         \r\n                      :!J5555555555J!:                      \r\n                  :~?Y5555555555555555Y?~:                  \r\n              .~?Y555555555555555555555555Y?~.              \r\n          .^7Y55555555555555555555555555555555Y7^.          \r\n      .:!J5555555555555YYYYYYYYYYYYYY5555555555555J!:.      \r\n   :!J5555555555555YY5PGB#&&&&&&&##BGP5YY5555555555555J!:   \r\n !Y5555555555555YYPB&@@@@@@@@@@@@@@@@@@&BPYY5555555555555Y~ \r\nJ5555555555555Y5G&@@@@@@@@@@@@@@@@@@@@@@@@&G5Y55555555YJ7~^:\r\n555555555555YYB@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@B5555YJ7~^^^^^^\r\n55555555555YP&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&Y7!^^^^^^^^^^\r\n5555555555YP@@@@@@@@@@@@&BGP5555PGB&@@@@@@@@BY!^^^^^^^^^^^^^\r\n55555555555@@@@@@@@@@@#PYYYY5555YYYYP#@@#57^^:^^^^^^^^^^^^^^\r\n555555555Y#@@@@@@@@@@PY555555555555YJ7!~^:^^^^!~^^^^^^~~^^^^\r\n5555555555@@@@@@@@@@GY555555555YJ7!^^^^^^^^~~P@&~~^^~?@@?~^^\r\n5555555555@@@@@@@@@@55555555J7~^^^^^^^^^^^^G@@@@@&^?@@@@@@?^\r\n5555555555@@@@@@@@@@GY55Y?!^:::::::^^^^^^^^~~P@#~~^^~7@@7~^^\r\n555555555Y#@@@@@@@@@@5~^::::::::::::::~~^:^^^^~~^^^^^^~~^^^^\r\n55555555555@@@@@@@@@@@5^...::::::...^5@@#P7~^:^^^^^^^^^^^^^^\r\n55555555555P@@@@@@@@@@@@#Y!~^::^~7Y#@@@@@@@@#57^^^^^^^^^^^^^\r\n555555555J7~^B@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@B:::^^^^^^^^^^\r\n55555Y?!^:::::7&@@@@@@@@@@@@@@@@@@@@@@@@@@@@&7::::::::^^^^^^\r\nJY?!^:::::::::.:7B@@@@@@@@@@@@@@@@@@@@@@@@B7:.:::::::::::^^:\r\n .::::::::::::::..^?P&@@@@@@@@@@@@@@@@&P7^..::::::::::::::. \r\n    ..:::::::::::::..:^!?YPGBBBBGPY?!^:..:::::::::::::..    \r\n        ..::::::::::::::............::::::::::::::..        \r\n            ..::::::::::::::::::::::::::::::::..            \r\n               ..::::::::::::::::::::::::::..               \r\n                   ..::::::::::::::::::..                   \r\n                       ..::::::::::..                       \r\n                           ..::..                           ",
                    ChoisesId = new int[] { 36, 37 },
                    ChoisesText = new string[]
                    {
                        "С тоже крут",
                        "Makefile ностальгия + ван лав"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 35,
                    Text =
                    "   Да... Вы вспоминаете как там чё-то это пытались немного\n" +
                    "на JS... Помните как там чё-то это говорили немножко...\n" +
                    "Помните как нашли у себя книжку про JS... Помните как сами\n" +
                    "хейтили JS... Но всегда... Всегда вас булили.... Не смотря\n" +
                    "на то на какой стороне вы были... Вы также там хотели\n" +
                    "немного изучить JS, но так это и не сделали... В общем\n" +
                    "да... Печально немножко так...\n\n" +
                    "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&BGGGGB&&&&&&&&#BGP55PG#&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&#.    ~&&&&&&P~.        :?#&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&#     ^&&&&&~              G&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&#     ^&&&&J     ?B#BP~ :7G#&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&#     ^&&&&!     G&&&&&#&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&#     ^&&&&G      :7PB&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&#     ^&&&&&G:        .^JB&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&#     ^&&&&&&&G7:         :Y&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&#     ^&&&&&&&&&&#PJ~.      ~&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&#     ^&&&&&&##&&&&&&&B^     P&&&&\r\n&&&&&&&&&&&&&&&&&BY^:G&&&&G     !&&&GY~  J#&&&&&&7     5&&&&\r\n&&&&&&&&&&&&&&&#~     :!!^      G&&#~      :~!!~.     :#&&&&\r\n&&&&&&&&&&&&&&&&B!            :G&&&&&5^              7#&&&&&\r\n&&&&&&&&&&&&&&&&&&#57^:..::~JG&&&&&&&&&B57~::..::~?P#&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&",
                    ChoisesId = new int[] { 39, 40 },
                    ChoisesText = new string[]
                    {
                        "Ах да, я же использую Type Script",
                        "Meh C#"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 36,
                    Text =
                    "   И вдруг вы вспоминаете:\n" +
                    "Ля а ведь C тож хорош... Настолько гигачад, настолько\n" +
                    "сигма, настолько хорош... Лучший и просто идеальный баланс\n" +
                    "между читаемостью и близостью к машинному коду.... Прадед\n" +
                    "всех языков, тру олд... со своими крутыми стандартами C89 и\n" +
                    "C99 и лучшей совместимостью со всеми устройствами... Со\n" +
                    "своим отсутствием зависимостей, просто прекрасный язык! Как\n" +
                    "он хорош... Как он приятен, люблю его.\n\n" +
                    "                                                            \r\n                                                            \r\n                          .~7JJ7~.                          \r\n                      .^7Y55555555Y7^.                      \r\n                   :!J5555555555555555J!:                   \r\n               .~?Y55555YYYYYYYYYYYYYY555Y?~.               \r\n           .^7Y555555YY5PB#&&&&&&&&#BP5YY5555Y7^.           \r\n        .7J5555555YYPB&@@@@@@@@@@@@@@@@&B5YY55555Y7:        \r\n       ^555555555YP&@@@@@@@@@@@@@@@@@@@@@@&PY555YJ7!.       \r\n       !5555555Y5&@@@@@@@@@@@@@@@@@@@@@@@@@@#J7!^^^^.       \r\n       !555555YP@@@@@@@@@@@#BGGGBB&@@@@@@@#Y!^^^^^^^.       \r\n       !5555555@@@@@@@@@&P5YYYYYYYY5G&#P7^^:^^^^^^^^.       \r\n       !55555YB@@@@@@@@BYY5555555YJ7~^^:^^^^^^^^^^^^.       \r\n       !55555Y&@@@@@@@&Y555555J?!~^^^^^^^^^^^^^^^^^^.       \r\n       !55555Y&@@@@@@@&Y55Y?!^:::^^^^^^^^^^^^^^^^^^^.       \r\n       !55555Y#@@@@@@@@P~^:::::::::::^^^^^^^^^^^^^^^.       \r\n       !5555555@@@@@@@@@5^...::::...~GBY!^:^^^^^^^^^.       \r\n       !555555Y5&@@@@@@@@@BY!~^~~75#@@@@@&P?~^^^^^^^.       \r\n       !555Y?!^:^B@@@@@@@@@@@@@@@@@@@@@@@@@@5::^^^^^.       \r\n       ^J7^:::::::7#@@@@@@@@@@@@@@@@@@@@@@B!::::::^^.       \r\n         ..:::::::.:~5#@@@@@@@@@@@@@@@@#Y~.::::::..         \r\n            ..:::::::.:^!YPB#&&&&#BPJ!^:.:::::..            \r\n                ..::::::....::::::...:::::..                \r\n                    ..::::::::::::::::..                    \r\n                        ..::::::::..                        \r\n                           ......                           \r\n                                                            \r\n                                                            ",
                    ChoisesId = new int[] { 38 },
                    ChoisesText = new string[]
                    {
                        "Пойти учить ассемблер"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 37,
                    Text =
                    "   Ляяяя, а мэйкфайл тож хорош.... Так удобен для\n" +
                    "компиляции, так прятен... Его так накрутить и\n" +
                    "накастомизировать можно: чисто удобно сделать разную\n" +
                    "сборку для разных ОС, для отдельных сценариев и случаев,\n" +
                    "так прикольно, так хайпово... Отдельное искусство это флаги\n" +
                    "компиляции... Разные оптимизации этих O0, O1, O2, O3,\n" +
                    "Ofast, но ладно их там всех кнш гораздо больше очень дофига\n" +
                    "и жесть там сколько разных, да прям жесть... Отдельная\n" +
                    "наука с ними прям, жесть, что да......\n\n" +
                    "\r\n@@@@@@&&#B#B5PPYJYPG#@@@@@@@@@@@@@@@@@@@@&#BBGG#BB#&&&@@@@@@\r\n@@@&B#BBY^!~JJJPYYGG##B5G@@@@@@@@@@@@@BG#&BB5JYJJ!!~P#BB&@@@\r\n@@PB&P..^PBG#&&@@@&#&&&&@@@@@@@@@@@@@@@&&&&&&@@&&BP5^.~BBG@@\r\n@5&@!  B#B&@@@@@@@@@@&&&&&&&&@@@@@&&&&&@@@@@@@@@@@@#BP  &&5@\r\n5&@P  GG&@@@@@@@@@&#&&GJ7!!7YB#B5~PG?!!JB&&&@@@@@@@@&B? :@&5\r\n5@@^ :#G@@@@@@@@&B#B!         ~B&BJB7.   .?B#&@@@@@@@GB  #@Y\r\n5@@! .BG@@@@@@&BBP:          ..P@@#@@7.     J##@@@@@@PB .&@Y\r\nY@@J  GG#@@@&BGP^ .~7JGB#G5B&@@##&@G&@@P~GY~ .5#&@@@##7 ^&@J\r\nGB@#. .?#B&BY7:~G@@@@@BG~.&@@@&5&@&Y#@!P&#@@@Y .!Y#GG^  Y@BP\r\n@P#@5.   .!. .B@@@@@@GG@P&@&&#B@&#@@@7^&@P@@@@&.  .   .J@BG@\r\n@@#G&@P~.   :@@@@@@@@@@@@&?J:^5@@#@@@P7:.?@@@@@#  .:7P&&G#@@\r\n@@@@#B&&&#P^@@@@@@@@@&#@@@BB7J&&@@@@@@#^~5@@@@@@&^J&&&##@@@@\r\n@@@@@@&&##JP@@@@@@@@&^@@@@@@@@@@@@@@@@@@GP5#&@@@@@YG&@@@@@@@\r\n@@@@@@@@@@?&@@@@@@@P5B#@@@@@@@@@&#&&&@@@@P~&#B##&&&5P@@@@@@@\r\n@@@@@@@@@?&@@@@&#?5&@@@@@@@@@@@~7B&&&##&@@#B##G@@@@@@@@@@@@@\r\n@@@@@@@PYG&GJ7BB&7B@@@@@@@&@@@@5&&^YG&@&&@@@@@5#@@@@@@@@@@@@\r\n@@@@@@@PB#G&5?@@@G?@@@@@@@@@&&@@@@@@@#@@@@@@@BY@@@@@@@@@@@@@\r\n@@@@@@@@@@@@P?@@@@JG@@@@@@@@@#5@@@@@@@@@@@&P?&@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@&^@@@@&5?&@@@@@@@@#5&@@@@@@@&&&@GY@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@7B@@@@@&7Y@@@@@@@@@#BGGGB#BBG5~#@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@?&@@@@@PYGB@@@@@@@@@@@@&&&&&#Y@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@PB@@@@@@B7~@&&@@@@@B7?5:!#&&@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@&G&@@@@@~7Y .P@@@@@@@@&J@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@&&@@@@@B7.^.B@@@@&YBG5@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@G!#G .&Y.  :&@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@B@@J! :     .^P&@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&@B:.::!^.~#@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { 38 },
                    ChoisesText = new string[]
                    {
                        "Пойти учить ассемблер"
                    }
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 38,
                    EndId = 9,
                    Text =
                    "   Вы понимаете, что уровня оптимизаций, на котором вы\n" +
                    "находитесь сейчас вам недостаточно, вы хотите больше,\n" +
                    "лучше, меньше, быстрее и решаете изучить ассемблер....\n" +
                    "Проходит не мало дней как вы его осваиваете и вот уже всем\n" +
                    "рассказываете, как он по своему хорош и крут.... Но\n" +
                    "питонистам будет не понять..... КОНЕЦ\n\n" +
                    "\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@BJ~~~!Y#@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#~.......:7&\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@&&&@@@@@@@@@@@@@@@@@@@^.:::::::..!\r\n@@@@@@@@@@@@@@@@&&GY?!~^^^::^^^~!?YP#&@@@@@@@@@@~.:::::::..7\r\n@@@@@@@@@@@@@BJ!^....................:~JG&@@@@@@J........:?&\r\n@@@@@@@@@@B?:.....::::::::::::::::::.....:!P&&5^.~55?77JP#@@\r\n@@@@@@@&5^...::::::::::::::::::::::::::::...:^.!G@@@@@@@@@@@\r\n@@@@@@5:..::::::::::::::::::::::::::::::::::...?&@@@@@@@@@@@\r\n@@@@#~..:::::::::::::::::::::::::::::::::::::::.:P@@@@@@@@@@\r\n@@@P:.::::::::::::::::::::::::::::::::::::::::::..J@@@@@@@@@\r\n@@P..::::::::::::::::::::::::::::::::::::::::::::..?@@@@@@@@\r\n@#..:::::::::::::::::::::::::::::::::::::::::::::::.5@@@@@@@\r\n@~.:::.........:........::.......:.............::::.:&@@@@@@\r\nB.:::.!55?YGGY^.~5PGGPY^..~YGGG5!:Y5JJPG5!7PGP7.::::.Y@@@@@@\r\nY.:::.5@@&B#@@B.^PPPG@@&.!@@&PPP!:@@@#B@@@&B@@@!.:::.!@@@@@@\r\n?.:::.5@@!.:@@#.Y&&BB@@@::G&&&&#J:@@#..#@@^.Y@@7.:::.~@@@@@@\r\nY.:::.5@@7.:@@#^@@&J5@@@J^YYYP@@&^@@#..#@@^.5@@7.:::.!@@@@@@\r\n#..::.7GG~.:PBY.?GBGY7GBP~PB#BGY^:PBY..JGP:.!GG~.:::.5@@@@@@\r\n@7.:::....:....:.....................::....:....:::.:&@@@@@@\r\n@&:.::::::::::::::::::::::::::::::::::::::::::::::..G@@@@@@@\r\n@@B:.::::::::::::::::::::::::::::::::::::::::::::..Y@@@@@@@@\r\n@@@B:.::::::::::::::::::::::::::::::::::::::::::..5@@@@@@@@@\r\n@@@@&7..::::::::::::::::::::::::::::::::::::::..~#@@@@@@@@@@\r\n@@@@@@G~...::::::::::::::::::::::::::::::::...:5@@@@@@@@@@@@\r\n@@@@@@@@G!:...::::::::::::::::::::::::::....^5&@@@@@@@@@@@@@\r\n@@@@@@@@@@#Y~:.....::::::::::::::::......^JB@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@&G?~:..................:^75#@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&#GJ7!~^^::^^^~7J5B&&@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 39,
                    Text =
                    "   Но вы сразу вспоминаете, что никогда не использовали и\n" +
                    "не используете JS, вы используете TS, это абсолютно другое,\n" +
                    "никто не знает, что это такое, хорошо...\n\n" +
                    "  :~7777777777777777777777777777777777777777777777777777~:  \r\n.!77777777777777777777777777777777777777777777777777777777!.\r\n777777777777777777777777777777777777777777777777777777777777\r\n777777777777777777777777777777777777777777777777777777777777\r\n777777777777777777777777777777777777777777777777777777777777\r\n777777777777777777777777777777777777777777777777777777777777\r\n777777777777777777777777777777777777777777777777777777777777\r\n777777777777777777777777777777777777777777777777777777777777\r\n777777777777777777777777777777777777777777777777777777777777\r\n777777777777777777777777777777777777777777777777777777777777\r\n777777777777777777777777777777777777777777777777777777777777\r\n777777777777777777777777777777777777777777777777777777777777\r\n77777777777777777777777777777777777777777!777?????7777777777\r\n7777777777777J&&&&&&&&&&&&&&&&&&&&B777775B#&@@@@@@@&&B777777\r\n7777777777777Y@@@@@@@@@@@@@@@@@@@@@777G@@@@@@@@@@@@@@@?77777\r\n7777777777777JBBBBBBB@@@@@@&BBBBBBG77B@@@@@@BPYYY5PB&&?77777\r\n77777777777777!!!!!!!&@@@@@5!!!!!!77?@@@@@@G!!!7777!77777777\r\n777777777777777777777&@@@@@5777777777&@@@@@@#5J77!7777777777\r\n777777777777777777777&@@@@@5777777777?&@@@@@@@@&#GY?77777777\r\n777777777777777777777&@@@@@577777777777Y#&@@@@@@@@@@#J777777\r\n777777777777777777777&@@@@@5777777777777!7J5B&@@@@@@@@P77777\r\n777777777777777777777&@@@@@57777777777777777!7?5&@@@@@@?7777\r\n777777777777777777777&@@@@@5777777777G5?77!!!!!!P@@@@@@?7777\r\n777777777777777777777&@@@@@5777777777@@@&#BBBB#&@@@@@@B77777\r\n777777777777777777777&@@@@@5777777777&@@@@@@@@@@@@@@&5777777\r\n777777777777777777777P#BBBBJ777777777J5GB##&&&&#BG5?77777777\r\n.!77777777777777777777!!!!!777777777777!!7777777!777777777!.\r\n  :~7777777777777777777777777777777777777777777777777777~:  ",
                    ChoisesId = new int[] {41},
                    ChoisesText = new string[]
                    {
                        "Ненавижу фронтенд"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 40,
                    Text =
                    "   Да ещё же этот есть C#, но он такой высокоуровненький,\n" +
                    "ме, как буд-то прикольный, но через чур сладенький, а ещё\n" +
                    "там эти вшитые в него работы с бд и XML, эта его УДОБНОСТЬ,\n" +
                    "через чур удобная меееех... А ещё я хейтер баз данных, если\n" +
                    "они не джосами на гитхабе...\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@&&&&#GYJJYG#&&&@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@&&&#GY?77777777?YG#&&&@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@&&&&B5?7777777777777777J5B&&&&@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@&&&&#PJ777777777777777777777777JP#&&&&@@@@@@@@@@@\r\n@@@@@@@@&&&#GY?777777777777777777777777777777?YG#&&&@@@@@@@@\r\n@@@@&&@&G5?777777777777JYPB##&&##BG5J777777777777?5B&@&&@@@@\r\n@@@&&&Y77777777777775B&@@@@@@@@@@@@@@@#P?777777777777J&&&@@@\r\n@@@#@P!7777777777?G@@@@@@@@@@@@@@@@@@@@@@#J7777777!!~^Y@#@@@\r\n@@@#@57777777777P@@@@@@@@@@@@@@@@@@@@@@@@@@B?7!!~~~~~~?@#@@@\r\n@@@#@5777777777B@@@@@@@@@&BPYYYY5G&@@@@@@@#5!~~~~~~~~~J@#@@@\r\n@@@#@577777777G@@@@@@@@&Y7777777777JB@&P?!~^~~~^~~~~~~J@#@@@\r\n@@@#@57777777J@@@@@@@@B777777777777!~!~^~~~J&@B5#@#J~~J@#@@@\r\n@@@#@57777777P@@@@@@@@777777777!!~~~~~~~~~~5@@&B&@@5~~J@#@@@\r\n@@@#@57777777P@@@@@@@@77777!~^^^^~~~~~~~~~~J&@#5&@&J~~J@#@@@\r\n@@@#@57777777J@@@@@@@@B!~^^:::::::^^^~~^~~~5@@&B&@&5~~J@#@@@\r\n@@@#@577777777G@@@@@@@@B!::::::::::^P@&P?!~^!7~^!7!~~~J@#@@@\r\n@@@#@5777777777B@@@@@@@@@&P?!!!!?5#@@@@@@@#5!~~~~~~~~~J@#@@@\r\n@@@#@5777777!~^:J@@@@@@@@@@@@@@@@@@@@@@@@@@G^^^~~~~~~~J@#@@@\r\n@@@#@P!7!~^^:::::^5&@@@@@@@@@@@@@@@@@@@@@G!::::::^^~~^Y@#@@@\r\n@@@&&@?^:::::::::::^7G&@@@@@@@@@@@@@@&BJ^::::::::::::7&&&@@@\r\n@@@@&&@#P?^::::::::::::~7YPGB##BBPY?~^:::::::::::^7P#&&&@@@@\r\n@@@@@@@@@@&#57^::::::::::::::::::::::::::::::^!YB&&@@@@@@@@@\r\n@@@@@@@@@@@@@@&BY!::::::::::::::::::::::::~JG&&@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@&&G?~::::::::::::::::^?P#&@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@&#P7^::::::::^!5B&&@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@&B57!~7YB&&@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] {41},
                    ChoisesText = new string[]
                    {
                        "Ненавижу фронтенд"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 41,
                    Text =
                    "   Ну и да эти фронтенды ваши вообще кринж, устал я чёт от\n" +
                    "этих всех htmlев, cssов, дааа.... Ну нет они кнш\n" +
                    "прикольненькие и всё такое, но хз, бесят уже, что xml, что\n" +
                    "фронтенд, одно и то же всё копии копии копии...\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@&&@@#&BBBB&B&@@#B@#@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@?.&B B#^:##  GP  &.P@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@?.BP #@7~@& G.:G &.J&&@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@BG@@5&@BG@&5&&&&5&P55G@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@G??????????JJ??J??JJ??J????J?JJJJ??????????Y@@@@@@@@\r\n@@@@@@@@#7????????????????????JJJJJJJJJJJJJJJJJJ??7P@@@@@@@@\r\n@@@@@@@@&?????????????????????Y5555555555555555J??7B@@@@@@@@\r\n@@@@@@@@@?????????????????????Y5555555555555555J??7&@@@@@@@@\r\n@@@@@@@@@Y?????7G@@@@@@@@@@@@@@@@@@@@@@@@@@&Y5YJ???@@@@@@@@@\r\n@@@@@@@@@P?????7P@@@@@@@@@@@@@@@@@@@@@@@@@@&Y5Y???J@@@@@@@@@\r\n@@@@@@@@@B7?????Y@@@@@@&&&&&&&&&&&&&&&&&&&&GY5Y???5@@@@@@@@@\r\n@@@@@@@@@&7?????J@@@@@@?7?????YYYYYYYYYYYYYY55J??7G@@@@@@@@@\r\n@@@@@@@@@@???????&@@@@@J7?????YYYYYYYYYYYYY555J??7#@@@@@@@@@\r\n@@@@@@@@@@J?????7#@@@@@&&&&&&&&&&&&&&&&&&&#555J???&@@@@@@@@@\r\n@@@@@@@@@@5?????7G@@@@@@@@@@@@@@@@@@@@@@@@&Y5Y???J@@@@@@@@@@\r\n@@@@@@@@@@G7?????5@@@@@@@@@@@@@@@@@@@@@@@@#Y5Y???Y@@@@@@@@@@\r\n@@@@@@@@@@#7??????JJJJJ???????Y5555YB@@@@@GY5Y??7P@@@@@@@@@@\r\n@@@@@@@@@@&???????&@@@@&??????Y5YYYY#@@@@@PY5J??7B@@@@@@@@@@\r\n@@@@@@@@@@@J?????7&@@@@@J7777?YYYYYY&@@@@@5Y5J???&@@@@@@@@@@\r\n@@@@@@@@@@@Y?????7B@@@@@@&#GP5PGB#&@@@@@@&Y5Y????@@@@@@@@@@@\r\n@@@@@@@@@@@P7?????P@@@@@@@@@@@@@@@@@@@@@@#Y5Y???J@@@@@@@@@@@\r\n@@@@@@@@@@@B7??????Y5GB#&@@@@@@@@@@@&#BGP5Y5Y???5@@@@@@@@@@@\r\n@@@@@@@@@@@&7????????777??JYPGBBGP5YYYYYY555J??7G@@@@@@@@@@@\r\n@@@@@@@@@@@@??????????????????YYY55555YYYYYJ???7#@@@@@@@@@@@\r\n@@@@@@@@@@@@G5YJ??77??????????YYYYYJJ???777??J5P@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@&&#GP5JJ?????????????JYPGB&&@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@&#BPYJJYPG#&@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { 42 },
                    ChoisesText = new string[]
                    {
                        "Перейти на ImGui"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 42,
                    Text =
                    "   Но вы вспоминаете, что в мире есть лучик света и это\n" +
                    "imgui - прекрасная вещ для написания интерфейса, удобная,\n" +
                    "быстрая, кайфовая, хайповая, прекрасная, удобная,\n" +
                    "легковесная, быстрая, C++овая, удобная для интегрирования в\n" +
                    "разные проекты и штуки, шедевр, объединаяющий всё, что вы\n" +
                    "любите, теперь вы можете стать счастливым... КОНЕЦ\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&#@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@&@@@&##BGG@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@BB#@@#BB#@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@&5?JJ77YG&@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@5~!YBGPPGGJ!!P@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@&^!B#B#&GG&#B#B~^&@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@:!@&#BGB##BGB#&@~^@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@#.B#GBBB&@@#BBBG#P.&@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@&.?@&#BB####BB#&@7:@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@B:J&BG##GG&#GB&?:#@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@&?~7P&GGGB&57^?&@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@BY?777??YB@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@PB@@@@@@@@@@@@@@@@@@@@&&@@@@@@@@@@@@@@@@@@@@@@@@@&@@@\r\n@@@@#B#.~@@#B#@@@&B#&&@&&#&@@&#@@@@&@@&@@@@@&@@@@@@@@@@@#@@@\r\n@@&^~PJ.!B:75~^#7^55::&::J#@@#B@GB&#G#&BB@#B&&GB@G#@@G&&G@@@\r\n@@B J@B.!Y 75Y~P:~@&^.#.!@@@@BB@G#@&P&@#G&G#@@BB@G#@&G&&P@@@\r\n@@@B??YJP@GJYYP@&Y?YYJ@JG@@@@&&@#&@@#@@&#@&###GB@@#&#&@@#@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&####@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 43,
                    EndId = 11,
                    Text =
                    "   Заходит как-то улитка в бар иии..... АХАХАХХАХАХ УХАХАВХ\n" +
                    "хахаХВАХХВАхвхАВХХАВХх ВЫФАДЗХЫХВАДХЫВАХЫВДЛАХЗВЫАЗЫВХАД\n" +
                    "УЛИТКА ЗАХОДИТ В БАР БОЖЕ ДЛОЛ ВЫ ЭТО ВИДЕЛИ, ЛУЧШАЯ ШУТКА\n" +
                    "В МОЕЙ ЖИЗНИ УХУХХУХАХУХАУХУАХХАУХАхаУХХАУХУАХАУхаухахУХАху\n" +
                    "АХАХХАУХАУХ XDXDXDXDXDDXDX ОЙ ЧЁТ МНЕ ПАЛОХО СТАЛО ПХПХПХХВ\n" +
                    "ХВАХАВХАВХаххаххвааааааааааааааааааааааааа XP X_X RIP\n" +
                    "СМЭРТЬ, рассказчик здох на этом моменте.\n" +
                    "ЗАХОДИТ КАК-ТО УЛИТКА В БАР А ТАМ....\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@&#BGGGPPPGB#@@@@@@@@@@@@@@@@@@@@&&@@@@@@@@@&@@@@\r\n@@@@@@@@@&BGPGGBBGGGGPPP5G#@@@@@@@@@@@@@@@@@B@@@@&&@@@@@@@@@\r\n@@@@@@@&BBBBGGGGPGGBGBGPP55G&@@@@@@@@@@@@@@#B@&#&@@@@@@@@@@@\r\n@@@@@@#GBGPPP5PG5PPPPBGP55555B@@@@@@@@@@@@&5PB#@@@@@@@@@@@@@\r\n@@@@@&JJJ?7Y5JJY?5YY55P5YYJJJ?#@@@@@@@&#P55YJPG#&@@@@@@@@@@@\r\n@@@@@P?7!!?Y?777!J????J?7?777!7@@@&#G5YYYJJJJ5BYG@@@@@@@@@@@\r\n@@@@@G?77??!!~~^!7!!!777!!~!!^~5P5YYYJ?7!!?YG#&&@@@@@@@@@@@@\r\n@@@@@@Y!!~^^^^~!!7!~~!!~^:::.^7JJ??7~~!!?JP&@@@@@@@@@@@@@@@@\r\n@@@@@@#?^^^^^~~..:.  .......:^~~~~~!7?YPB@@@@@@@@@@@@@@@@@@@\r\n@@@@&B5!:.................::^^^!!7JYP#&@@@@@@@@@@@@@@@@@@@@@\r\n@@@@#BP5J7~^^^^^^^:^:^^^^~~!!7?JY5G#&@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@&&#BGGP5YYYJ?J?JJJJYY555555PGB##&&&&@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@&&&##BBBGGPPPPPPP55555GGBBBB##&&&&@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@&&&&@@@@@@@@@@@&&&&&@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 44,
                    Text =
                    "   ВЫ СО ВСЕЙ СКОРОСТИ ЗАЛЕТАЕТ НА САЙТ, НО ВДРУГ!... Ваше\n" +
                    "внимание привлекает загадочный красочный банер... это же\n" +
                    "RRRRRRRRRRRRAID SHADOWWWWWWW LEGENDSSSSSSSSSSS!!!!!!!!!!!!!\n" +
                    "!!! ЛУЧШИЮ ОНЛАЙН ММО РГП С МИЛЛИОНОМ ПЕРСОНАЖЕЙ, ВЫБЕРИ\n" +
                    "СВОЕГО ЛЮБИМОГО И ПОЙДИ ЗАЧИЩАТЬ ПОДЗЕМЕЛЬЯ!!! ПОЛУЧИ\n" +
                    "БОНУСНЫЙ КЕЙС С ПЕРСОНАЖАМИ И 2 НЕДЕЛИ ПРЕМИУМА СЕЙЧАС-\n" +
                    "СЕЙЧАС!!!!\n\n" +
                    "B############BBGG#&&&&&&&&Y ~&##^.5&&&&&###############BJJ??\r\n##########&&&&&##BB##BBBBP. Y&#&~ ^B&####&#&&#BGGB&&###PJJJ?\r\n###########&&&&&&#B######?.^####5.:P##B##&&#PP5?!!Y&&&BJJJJ?\r\n############&&&&&&&&&&&&&J.!&#BBG.:PB#&&&&G7JJ!!~::J&&G5JYJ?\r\nB##&&&&&&###BGG&&&&&&&&&&G:.P&&&J.7#P#BBBG5:^!77:..?P5?7YYJ?\r\nY#&&&&&&&&&P^~!Y&&&&&&&&&&5^:G&Y::J5YJ777~^. .~^.    ..:7J?7\r\n?Y#&&&&&&&#7:7JGB&&&&&&&&&&G!^!~!J?77?7!7!^.....   ..:^::^!?\r\n7??GB####&P~^!B#B#######&&&B77JY?YJYJ?J??J?^^!!~:..::^^^^::~\r\n7??PGG#&#G?!~?GBBB&&&&&&&&P~^!G5^?P5YYYYYJJYGBP7^^:^^:.::^::\r\n!7?G5J55?!!!~~~!!?5B&&BP?~::^~7!^~BBGPP55PGGGP77~^!~^:.....^\r\n!!?Y7!!~~~:..^~77?5GBB#P^:..~7?Y!:!YG&G5G#BPGJ:^^J?~^^.....!\r\n!!?J::::...^~:~?J5PP!~7!!~^~7!7?J~~!!!~!JGPPY!^^^J7~Y!..:::7\r\n!7Y5^::..:~7?~!?5P?^!^^~!!?YJ?7J5?JJ~777~^5?^~!!!!^^^::::::^\r\n?J5P^:::^^~!?7Y55P!.^::?~~!7Y5BGBY!!~~~^~:!?:^~^~!~:.::~::~~\r\n?J5!:::?^^~!7!Y5GP^::  .::^^~~!!!~^~::.....7~..::... :^~~::~\r\n?^:.:.?5:::^!7JY5~ .  :!:~::^:~!^:^^^55~....~^.::.....^~!~::\r\n7:.:::~:^~^7YGY57..:.?GP7:^^^^~~^.::!PBJ:~^:J?777~.::.:^^!~^\r\n!::::^::P&&&&&&&BJ:.:BG5&&&&B::::.Y&&&G?^B&&&&&&&BJJ?~.:^~!~\r\n7^^:^:..G&&&?~Y&&@Y ^GYP&&&&&!.7!:5@&&Y~^G#GP!^?PGB!:~~::^^^\r\n!^^~!:..5#BB^:!#B#J.!5!PBBB##5:^^.7YJ?^~^?5PP:.?&##7:^~::^^!\r\n?!~7~::.7YYY~~?5557.77^J?7^!!~^.:.^??Y^::YPPP^.7GGG~.^:~J^^!\r\n??7?~:::!JJJJJJ??7~^~::^^^.!?J!...!YJY:.7JJJJ:.!YJY^.::~BJ:~\r\n7?JY~:::~!~~^~!77:...:YYY?~?YYJ.::!JJJ~ ^JJJJ^.~JJJ~:^^:^7^^\r\n77??:::^~!?J^~Y55J!7^!5YYJJ?JJJ~::7YYY~^~?YYY7~7JJ?::^^:..^^\r\n!!!~::::::~!^:!??J?7.77?!:.:7?7!. ^???^^??77?777!:::::^::.:^\r\n~~~^^^.:J~:??~~Y~!Y? !7^!!!7. ~: ~!^J?.!5~7J?~J7:?!.::::.::^\r\n^^^^~:.:JJ:PP!7G77Y5.5Y!^GPY  ?7.5J:PJ^75:YBJ!Y5:JJ::....::^\r\n::::^:..:^.^^^~^~::. .^::::.  .:.:^:^^..^:^^::^^:^~::...::::",
                    ChoisesId = new int[] {46},
                    ChoisesText = new string[]
                    {
                        "НЕЕЕЕЕЕ, НУ РАС 2 НЕДЕЛИ, ТО НАДО БРАТЬ......"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 45,
                    Text =
                    "   Время для получения бонуса закончилось, хоть вы и до сих\n" +
                    "пор можете перейти по ссылке и возможность получить бонусы\n" +
                    "не прапала.... Но оно вам нужно???? Вот именно, зачем вам\n" +
                    "это, если у вас 20 миллионов мощи в кингдом райз.... Что?\n" +
                    "Интересно узнать как вы их получили? Всё просто: пока все\n" +
                    "развивались, вы выбрали викингов и ограбели всех этих\n" +
                    "недоразвитых, развившись ещё сильнее, чтобы прокачать свою\n" +
                    "армию и грабить ещё более богатеньких. Стоп, вы хотите\n" +
                    "также? Переходите по реферальной ссылке в описании и\n" +
                    "получите бонусные 1000 золота......\n\n" +
                    "##&#&&&&&@@@@@@@@@@@@@@@@@@@&@@@&&&&&&&&&&&&&&&&&&&&&&&&&&&&\r\n#####&&&&&@@@@@@@@@@@@@@@@@@@@&@@&&&@@@&@@&&&&&&&&&&&&&&&&&&\r\n###&&&&&&&&&@@@@@@@@@@@@@@@#GB#&&@&&@@@&&&&&&&&&&&&&&&&&&&&&\r\n&&&&&&&&&&&@&&&@@@@@@@@@@@B!?PBBB&&@@@&@@&&&&&&&&&&&&&&&&#BG\r\n&&#&&&@@@@@@@@@@@@@@@@&B5!^^?Y555?75BB&&@@&&&&&&&&&&&&&&&#YP\r\n&&&&&&@@@@@@@@@@@@@#PJ!~^:.^^~J?7~~~777YB&&@&&&@@&@&&&&##J!5\r\n&&&&&&@@@@@@@@@&&BY~^::::..:.~7~:^::^^^^!75#@@&B5PBBBBB55~7?\r\n&&&&&&&@@@@@@@@&J~:..........:^~7:....::::^!P&&!~~~~!~~~7^7!\r\n&&&@@@@@@@@@@&&#7::....:....^:^?^......::^~~J&@&GB@@@@@J~!~!\r\n&&@@@@@@@@&&&&@@#YJY7.......::^:.......^J5PB&@@@@@@@@@@&&BG#\r\n@@&&@@@@@@@@@@@@#577~........:^.......:^7JJG&@@@@@@@@@@@@@@@\r\n@@@&&&&@@@@@@@B?YJ!:~G:::.....:...:::^^BY^Y55P#@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@B^:^^:^&@G..:....::::^^::Y&@?^^^!!B@@@@@@@@@@@@\r\n@@@@@@@&&&@@&7::::?#@@5......:::.:75Y!5@@&7.:^^?&@@@@@@@@@@@\r\n@@@@@@@@@@@&J~^..!77&G...:^~^:::.^JPG7~&&&G~.:^~PBPPG&@@@@@@\r\n&&&&&@@@@@&5?!::^~JGY.....::::::..~?Y^:7&#BP7:^YY55YYGB##&@@\r\n&&&&#&&#GJ~!~7YB&B#5:.......:^~^:...^^^~?5Y5P5!7:7GB#&&&&#55\r\n&&&#GY7~75GG#&&&&&Y::::...:~^~~^::..::^~!?PGP5PJ7~?#@@&@@&##\r\nPY!~!7JYPGGB#####J:::.....^7^~~^^:::::::^~5@&#####57JB&&&&&&\r\n7?JY55GPGBBB#&##P^^:::::::!!:~~^~^^^^:::^^~5####BB##5!!5B###\r\nB##BGBBBB#####&#7!~~^^^~^^!!??JY7:^^^~~~~!7??5GGB###B#P~~J#&\r\n~!JPB##BB#BBBB&Y!7!!!~~~^^:7&#BB5^:^^^~!!7?7J5GBB#&#BB#&B!^7\r\n^?####B###&&&&&&Y!777!!!77!5###&&PJ~^~~!!!77Y##&##&##B?5BP^^\r\n7?YGBG####&&&&&&Y7~^!^~^^^:~5G#&&&&B?~~!7?7!J##&&&&&&&G::^5#\r\n!77??YPB#BPY?7YY~7!~~^^^::.:::^75G##G7JY5JJ7?###&&&&&&&G^P&&\r\n##&&###B7^::^:::.^~^:.:........:^~~!~7!^~^^:^JG&&&&&&##&#&&&\r\n&&#B#GP^:..:^......................::...:::...:!JPB#######B#\r\nBG?~^:..........................................::!!7B&#&GJ!",
                    ChoisesId = new int[] {47},
                    ChoisesText = new string[]
                    {
                        "Не ну если 1000 золота... (стать викингом)"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 46,
                    Text =
                    "   Вы залетаете на страничку RAID SHADOW LEGENDS и вдруг\n" +
                    "что-то вспоминаете.... Что-то очень-очень важное.... это\n" +
                    "же..... LEGENDS NEVER DIEEEEEEEEEEE, WHEN THE WORLD IS\n" +
                    "CALLING YOUUUUUUUUUUUUUUUUUUUUU CAN YOU HEAR THEM SCREAMING\n" +
                    "OUT YOPUR NAAAAAAAAAAAAAAAAAAAAAME!!!!!!!!!!!!!!!!!!!!!\n" +
                    "LTGENDS NEVER DIIIIIIIIIIIIIIIIIIEEEEEEEEE, THEY BECOME A\n" +
                    "PART OF YOUUUUUUUUUUUUUUUUUUUUUUUUU, EVERY TIME YOU BLL\n" +
                    "LEDDING NOUT FOR GREEEEATNNENEEEEEEEEEEEEES!!!!!!\n\n" +
                    ".          ..          ..          ..          ..          .\r\n                                                            \r\n     ..  .~:  .~!!7: ~77~..!~!~.~^ .!^:!!!!. :777:   ..     \r\n     ..  ^&7  .&#!!:J&J7#J^&Y!!.BBY.@57&J~#B:@B7G#:  .      \r\n         ^&7  .&&PJ 5&.?BY^&G5~.#G&P&J7#. B&.GB5PY.         \r\n.        ^&?::.&&~~.5@~~&5^&Y~^.@Y^#&?!#!:#&:BY~5&^        .\r\n         :5JJJ:5P5P~.J55J:^5555.57 ~P!~5PP5~.7P5Y~.         \r\n         :BPY  Y#7.GBGB#5 5#7  .B#:^#BBBBJ.B&#BBB!.         \r\n     ..  ^&&&P G@J:&&~:^: ~@&. Y@P !@&^::::#@!:^&@^  ..     \r\n         ^@&#@JG@J:&&GG5.  G@Y:&&. ~@&YPY .&@PJ?B&:         \r\n         ^&#^B&&@J:&&?77.  :&&#@?  ~&&!7! .#@PYJB#:        .\r\n.        ^&&..#@@Y:@@J77!   Y@@&.  !&#?7?^.@@: .&&^        .\r\n         .Y5. :PG!.JYPP5?   .5P~ . :5Y5PG7.PP: .5P:         \r\n     ..  :B##&BBGGGGBBG~    .PGGBB. :BBBGGGG##&##B:  ..     \r\n     ..  ^&@&@@@&&&&@@&@#7  .#&&&#. ^&&@&&&&@@@@@&:  ..     \r\n         .#&&@&??????#&&@&: .&&&&#. :##&&&??7???!!.         \r\n.        :#&&&#      B&&&&: .&&&@B. ^#&&@B                 .\r\n         ^&&#&#      G&&&&: .&@@&5. ^&&&&#.......           \r\n         ^&&#&#      P&@@@: .&&&&B. ^&&&#&&##&&#7           \r\n     ..  ^@&&@#  ..  B@@@&: .B###G. :&@@&&@&@@@@J    ..     \r\n         ^@&&@#     .#@&&&: .##&&#. ^&&##B!^?777^           \r\n         ^@&&@#      B&#&&: .@&&&&. ^&BBBB                  \r\n.        ^&&&&&......##&&#: .&@&&&. ^##&&B........         .\r\n         :&&&&@&&&&&#&&&&B. .&&&&#. :@@@&&&&&&&&&&^         \r\n      .  :@@@@#&@@@@@@&G~.  .&&##B. ^@@@@@@@@@@@@@^         \r\n     ..  .!7!!^:!!!!!!~     .!!~~^. .777!!!!777777.  ..     \r\n                                                            \r\n.          ..          ..          ..          ..          .",
                    ChoisesId = new int[] {48},
                    ChoisesText = new string[]
                    {
                        "Стать рок звездой"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 47,
                    Text =
                    "   Вы решаете стать викингом.... Но вдруг вы резко\n" +
                    "останавливаетесь и задумываетесь..... Всё это произошло так\n" +
                    "резко.... Типо так резко свалилось на вашу МИНРНУЮ жизнь,\n" +
                    "что прям её ПОТРЕВОЖИЛО.... как буд-то.... как буд-то....\n" +
                    "DESTURBING THE PEEEEEEEEEEEEEEAAAAAAAAAAAAAAACEEEEEEEEEEEEE\n" +
                    "EEE!!!!!!!!!!!!!!!!!  LOOOOOOOOOOOOOOOKKKK INTO MYYYYYYYYYY\n" +
                    "YY EYEEEEEEEEEEEEEESSSSSSSS!!!!!!!!! NOW TEEELLLL ME THE\n" +
                    "THING YOU BLABING ABOUT ME BEHING MY BAAAAAAAAAAAAAAACK!!!!\n" +
                    "!!!!! THE TENACITYYYYYYYYYY!!!!!!!!!!!!!!!!!!!!! I HOLD\n" +
                    "IT'S HAHRD RTO BREAK DOWWWWWWWNNNNN@!!!!!!!! IRT'S TOI LATE\n" +
                    "FOR APPOILOGIESSSSSSSSSSSSSSSSS!!!!!!!!! IT\"S GOING DOWN\n" +
                    "NOW!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n" +
                    "YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY55YYYYYYYY\r\nYYYYYYYJ7YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY5YY55YYYYYYYY\r\nYYYYYYYY.~YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY5PYYYYYYYYYYYY\r\nYYYYYYYY! ~YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY\r\nYYYYYYYYY7:YYYYYY?7JYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY\r\nYYYYYYYYYY^YYYYJ::JYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY\r\nYYYYYYYY?..YYYJ. JYYYYYYYYYYYYYYYYYYYYYY7!JYJJYYYYYYYYYYYYYY\r\nYYYYYYJ: .JYYY7 7YYYYYYYYYYYYYYYYYY?!JYY: .!^7YYYYYYYYYYYYYY\r\nYYYYY~  ~J?YYY~^YYYYYYYYYYYYYYYJJY!::?J!:   .~~JYYJ?!JYYYYYY\r\nYYY?. :JJ. 7YY!YYYYYY5YJJJJJJJJJ~^:...:.      :!Y?!?7JYYYYYY\r\nYYY..?5~   ~Y^7YYYY5&@&&BGBY7GJ5G?:            .J7?7~YYYYYYY\r\nJY?.J5^   :J.:YYYYY&@@@@@@@&&@@&@@P.            ~!~.7YYYYYYY\r\nJ?~.J^   ^7.:YJ7!!P@@@@@@@@@@@@@@&G7.               YYYYYYYY\r\n!Y7.^  :?~ .^::^!^ ?@@@@@@@@@@@@@&&@@#?             ~YY55YYY\r\n.~?:  :~..:~J5GP7 .&@@@@@#GP&&&&@@&B&#@G    .       .JY55?!Y\r\n7!!.    .::~!7:.~5&@@@@@@&7 .^B7Y&57 ^&GJ    .       7JP5.^Y\r\n7!!. .!YPGGBB#&@@@@@@@@@@@#   .^ .5BJ&&PP.           ~~77!YY\r\n!7JJJB@@@@@@@@@@@@@@@&G&@@G        .?G#&:!        .:~^ ~YYYY\r\n ^B@@@@@@@&#&&&@@#@&&&?J@#J     .      ~.       :!:...~YYYYY\r\n~. :P@@@@&&@@@&#@Y!P&&G:^.:.    .:           .      .^7YYYYY\r\n     .5@@&@@@@&#G! . ..  :!!:   ^~          .       !^?PP5YY\r\n       .G&&&@@#J:  ..   .:~!!.  ~:.  ..  ..~^      ^~~YYYYYY\r\n         ^.~7?! ...    ^ .?555J. .  :^:  .::.    ..^!YYYYYYY\r\n      .:~??!!~~~7Y7~  :!^.^!7!:.    ..           :!JYYYYYYYY\r\n     .:::.!J?JYYYYYY7.^77^    .     :.         .~JYYYYYYYYYY\r\n       .:~!5YYYYYYYYYJ!!!~^        .         .!?JJYYYYYYYYYY\r\n  :~!~~!JYYYYYYYYYYYYYJ?77!:.             .!777?YYYYYYYYYYYY\r\n  ^!!!7JYYYYYYYYYYYYYYYYYJYJ77!^^~~!7777!!!J5JYYYYYYYYYYYYYY",
                    ChoisesId = new int[] {48},
                    ChoisesText = new string[]
                    {
                        "Стать рок звездой"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 48,
                    Text =
                    "   Вы настолько хорошо пели, что поняли, что вам пора стать\n" +
                    "рок звездой. Вы отправились со своей новой группой\n" +
                    "состоящей из себя и ещё разных себя на выступления по всему\n" +
                    "миру, поя фнаф сонги, битбокся, напевая мелодии из алан\n" +
                    "волкера, вдохновляя других челов стать шизами. 10 шизов из\n" +
                    "10 этому аниме, но я бы ещё на фоне включил jazz rap и\n" +
                    "рекламу овип локост. КОНЕЦ\n\n" +
                    "                 ::::::.  .:::::.::::::. ..^~~~^~^.^:^^^:^:^\r\n                :^:......   .:::::^^^^^:               .!!^7\r\n            . ..^:::^^^^^^:   .:^^^^:^^:          ...:^~!!!~\r\n            ^. ..:^!^ ...:: .^^^^^^^:^^^        :7!~~~~!!!!~\r\n  :      .  ^:.::^~!7.~.  .:^^^^^^:  ...      .  ~?7~^!~^~PP\r\n :^:     .: ^^^^^^^^^^^^^.::^^^^^:     :.     .   .!!!!77JYJ\r\n ^^^:  .  ^.^^^^^^^^^^^^^^::^^^^^: .::..~.        ..~YYP555Y\r\n.^^^^: .. .^^^^^^^^^^^^^^^^^^^^^^^^^::.::         ^5J55P55P5\r\n.^^^^^::^. ^^^^^^^^^^^^^^^^^^^:::..^.. .         :Y55GP55P55\r\n.:^:::::::..^^^^^^^^^^^^^^^.       .^:          ~PPP5PPP5P55\r\n:::.:^^^^::...:^^^^^^^^^^^^^::.   :^^^         .5PP55P5P5PYP\r\n^::   .^^::^^:.:^^^^^^^^^^^^^^^^::^^^:       . .YP555PP5PY5P\r\n^^^^:.  :^^^:^^..^.:::::::::::::^^::^.      ..  :PYP5PPGP5PG\r\n^^^^^^:..^^^^^^^ .^:::::::.......:^::.      ..   ~77Y:YG5PGP\r\n^^^^^^^: .^^^^:^: .:^^^::::...:^^^^:^^^:.   :.   .. ...5G55J\r\n:^^^^^^^^..^^:^^^:..:::^^^^^^^^^^^.:^^:^:.. Y?   ::. ..!5J77\r\n  .:^^^^^: :^:^:.:::^^^^^^^^^^^^^  ^^.  .~^.~7:..::... ~!J?Y\r\n     ..:^: :^:^.:^^^^^^^^^^^^^^: .^^^^^::^!!!~~::!^... .!7^!\r\n           :^^^^^^^^^^^^^^^^^^..:^^^^^^^:.~!~!^!J~....  .^77\r\n           ^^^^^^^^^^^^^^^^^^::^^^^^:.:: .^!^:755~....:.  .^\r\n          .^^^^^^^^^^^^^^^^^::^^^^:...^::.^:.~!~~^^::~^:..  \r\n          ::::::::::::::::::::::::..:^:::.^^^~~^^^7J^^!^::^^\r\n          .^:::::::::::::::::::::::::::. .~~^~~!7YPP7!!^^~:.\r\n           ..::::::::::::::::::::::::. ..^~~~JY5PPPPP!!!!^!~\r\n               ::::::::::::::::::::...::.^!~!5555YY55?::!~~^\r\n              .::::::::::::::::::::::::.:^!^~Y55YY5555^.... \r\n           .::::::::::::::::::::::::.. .~^^:^^~7JYYY?7^     \r\n           ::::::::::::::::::::::::..  ^~^^^^.  .^!:        ",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 49,
                    Text =
                    "   Вы поползли дальше по динозавру и нашли в нём путь к\n" +
                    "его мозгу. Дойдя до него вы попали в комнату с креслом и\n" +
                    "пультом управления. Не думая вы садитесь за кресло и теперь\n" +
                    "управляете динозавром. Немного поигравшись, вы вдруг видите\n" +
                    "в далеке уже подлетающий верталёт. Идя к нему на встречу,\n" +
                    "вдруг вы понимаете, что он не понимает, что это вы и походу\n" +
                    "собирается начать по вам стрелять.... Ваши действия?\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@&&&&&####BB####B##&&&#GB#&@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@&&BPBBBB##BYG&&#YY#&&#G?JB##BGGPG#&@@@@@@@@@@@@@@@@\r\n@@@@@@@&#GBG?PGB###B?JPPPY5B#B5!7G##G5J!5BBGG#&&@@@@@@@@@@@@\r\n@@@@@&##BGPY?YYYYP##B?!B###B5???G#BP?7YJ5PGP?5GGPG&@@@@@@@@@\r\n@@@&PGBGPBGYBPPBG5PPY!G#BYJ?P#&#G?!YB&B5PGGGPPPGG5P#@@@@@@@@\r\n@@#BGJ55P#BG5J?7??7^~7PBG?~P&##5?7~PGYY?YGPYJ?JY55?YYP&@@@@@\r\n@BBGP?Y5!??~JPJ!GB57G55B5~?GBGP~?PJ5P!^5GGPJYPGGPYJP5YJ#@@@@\r\n@Y55PPY!:JY!PBPJ5Y~JGPGP7^J5Y?7~:!77^~5GG5?^JP5!J5J?JJ?J&@@@\r\n@G?~~75PY7??Y5YJ?^^77!~^:~7!~~!JYPGP5PGPY7^!JYY!~!7??!?7#@@@\r\n@B~~^^~!?J7~^^^^75PPGPY5GGPP5PGPPG5J77!~^^?YY?7J??J7!!!^?#@@\r\n@@B!::::::^^^::7YJY55YJ55J?77!^^~~^^!!7?Y55YJ~!J?^^!!~!~!J&@\r\n@@@@B?^::::::^7??7~:^~~!7??7!?JYYJ?JJ?7~!??7777!7^!7~^^!~!B@\r\n@@@@@@@#PJ7~~^777??^J55YY55YYY7!!!JJJJYY5Y?7~:^77~~~^^^::!G@\r\n@@@@@@@@@@@@@&G?77Y?YY77777!~~!JYY77???7^:~!7~:^~!!!77!^^7G@\r\n@@@@@@@@@@@@@@@Y!!?7~J?J?!!~!!!7??!77!!!~^~^^!7!!~~~^^!JJJ&@\r\n@@@@@@@@@@@@@@@@P!^^!!!~~~^:::....::::::...:~^~!~^^^~~~7J&@@\r\n@@@@@@@@@@@@@@@@@#Y??!!7JG#~...........^~^....::^^^::^?G&@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@#~::::::::^~~~~~^:....:^^!YB@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@&?^:::^^^^^^^^^:::::::YBB&@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#5^.:^^^:::::::..:^?&@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@P^^^::^:::..:::!P@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@B!^^::!YBBGGB&@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@?~~^&@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&77!&@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] {51, 52},
                    ChoisesText = new string[]
                    {
                        "Сделать сальто динозавром вперёд",
                        "Сделать сальто динозавром назад"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 51,
                    Text =
                    "   Вы успешно делаете сальтуху, настолько успешно, что\n" +
                    "пилот с шока теряет управление и взрывается влетев в\n" +
                    "вас.... Неприятно... Что делать?\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@#55Y5#@@&&&@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@&7^:~7!~~!7~^^!Y@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@&BP5GBPJYY7:~??JYJJ7777!:.~!!75G5Y55#@@@@@@@@@@@\r\n@@@@@@@@@@&Y~7JYJ??YY?~~!?7?YYYY?J??!::~7JJJ555?~J&@@@@@@@@@\r\n@@@@@@@@@@P:!?JJYYYJ5J!!???JY5PGGGGPJ77JY5555YYY7^Y@@@@@@@@@\r\n@@@@@@@@@B::~777?JY5Y^^!7YY5YYGG5PYJY?~^J5YYJJ??7~:B@@@@@@@@\r\n@@@@@@@@@@#^^~!?????7:^~!?7??7JJ777!~^~77???JJ7!~:5@@@@@@@@@\r\n@@@@@@@@@@P::^^~~~~~^::.:^^~~~~^^:^^..::^^~~~~^^:.?@@@@@@@@@\r\n@@@@@@@@@@@J^:::........::::::^^^^~^::..:....::^~J@@@@@@@@@@\r\n@@@@@@@@@@@@&&&B?^~^^~^^:::7?5GPGJJ^::::::^7B&&&@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@#GGB#B#&##&5.~JPGY5!~7G5PGBPPBB#@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@&&&&@@@@@@&.^?55JJ:.5@@@@&#&#GG#@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@&&@&^:7YY??::&&&&@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@&@#G7.~7?7!.^B@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@#!7!:~!!~~:~~YP#@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@#&5^!^^!!!77~^~^^7B@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@&&@@@@@@G?J5J7~!?YPPP5Y7!77!!?&@@@@@@&@@@@@@@@@@@\r\n@@@@@@@&@&@@&#B&BP7!Y555?!?J55555Y77555J~YPJG&#B&@@@@@@@@@@@\r\n@@@@@@@@@@#GPY!~!!~~!77!~^!!7?????!!7?77!!!!!!!5#B&@@@@@@@@@\r\n@@@@@@@@@@@@@@&&&#&&&&#BB&&BBPPBB#&#BB##&&#&&&&&@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] {53, 54},
                    ChoisesText = new string[]
                    {
                        "Press F",
                        "Пойти в зоопарк"
                    }
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 52,
                    EndId = 13,
                    Text =
                    "   Вы решаете сделать сальто назад, но у вас не получается\n" +
                    "и вы падаете прямо на голову, ломая черепную коробку, в\n" +
                    "которой вы нахадились... Вы вылезаете из проделанной дыры и\n" +
                    "пилот в шоке вас забирает, а затем отвозит на базу. Там вы\n" +
                    "всем рассказываете о том как залезли в мозг динозавра, а\n" +
                    "потом когда прилетел верталёт, вы сделали вооот такое\n" +
                    "сальто *и повторяете то сальто назад*, в результате чего\n" +
                    "умираете.... И из вашей черепной коробки выходит какой-то\n" +
                    "муровей, которого забирает муха и они улетают за экран... КОНЕЦ\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@&@&GB&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@BPB5J5GGP###&&@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@&##PYJYYJ!YPB@@&&#&&&&@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@&#BBPYJJYPPPPPPGB#GGP555B##&&&&@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@&#BBPYJYG&@@@@@@#BB##&&&BPY??J5B#&#&&@@@@@@@@@@@\r\n@@@@@@@@@@###B5JYG&@@@@@@@@@@@@@@@@@@@@@#PJ?JP#&&#&@@@@@@@@@\r\n@@@@@@@@&B&#PJYB@@@@@@@@@@@@@@@@@@@@@@@@@@&BYJJPB&&#&@@@@@@@\r\n@@@@@@@B&&B5YG@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@G5JYG#&##@@@@@@\r\n@@@@@@#&&#PY#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#P5YG#&&B@@@@@\r\n@@@@@#@&&P5#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&PPYG&&&B@@@@\r\n@@@@B&&&#PB@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&GY5B&&#&@@@\r\n@@@&G@&&GG&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@GBYB&&&B@@@\r\n@@@BB&&&PB@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&B5B#&&#&@@\r\n@@@BB&&&GB@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&#5G&&&##@@\r\n@@@BB&&&GB@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&#5B&&&##@@\r\n@@@#P#@&BB&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#&G#&&&G&@@\r\n@@@@PG&@&BB&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&B#&&&#P@@@\r\n@@@@#5B&@&BB&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&BB&&&#P&@@@\r\n@@@@@BPB&@&BB&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#&BB&&&#PB@@@@\r\n@@@@@@BYB&@&#B#&@@@@@@@@@@@@@@@@@@@@@@@@@@@@&#&B#&&#BP#@@@@@\r\n@@@@@@@#P5#&@&BB#&@@@@@@@@@@@@@@@@@@@@@@@@&&&##&&&#5P&@@@@@@\r\n@@@@@@@@@G5P#&&&##B#&&@@@@@@@@@@@@@@@@&&&&#&#&&&#5PB@@@@@@@@\r\n@@@@@@@@@@&P5GB&&&&&B&B##&&&&&@&&&&&&&&&#&&&&#G5PB@@@@@@@@@@\r\n@@@@@@@@@@@@&G5PP#&&&&&&###&#&#&#&&&&&&&@##B55P#@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@&GG5PGG##&#&&&@#@&&&&&B#PP55G#&@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@&BG5PPYPPPB5GP5PYPPPB#&@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@&&&#BBB###&&@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 53,
                    Text =
                    "   Вы решаете отдать честь этому самому пилоту. Он был\n" +
                    "хорошим человеком, хоть вы его и не знали.... Да и умер\n" +
                    "ещё так.... От сальтухи динозавра.... Печальненько.... Ну\n" +
                    "ладно.... Хз как это развить, поэтому всё равно идите в зоопарк.\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@57???~.....~????????7!~:....?@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@@@@@&G:  :@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@@@@@@@@? .@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@@@@@@@@@: @@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@&P@@@@@@#:@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@7 @@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@P  @@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     ~P55J!.   @@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     ?&&&#BY.  @@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@. @@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@Y @@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@@#@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     Y@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@Y     J@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@5????~.....~?????#@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] {54},
                    ChoisesText = new string[]
                    {
                        "Пойти в зоопарк"
                    }
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 54,
                    EndId = 14,
                    Text =
                    "   Вы идёте в зоопарк, вас пугаются, но потом прощают, за\n" +
                    "то шо напугал. Вы успешно работаете в зоопарке пару лет,\n" +
                    "пока о вас не узнают учёные, как о разумном динозавре. С\n" +
                    "вами пытаются наладить контакт, научить своему языку... Но\n" +
                    "лол, выж это всё уже знаете... В общем вам было скучно\n" +
                    "общаться по человечески, поэтому вы придумали язык общения\n" +
                    "сальтухами на асбуке морзе и теперь учёным нужно звать\n" +
                    "профессиональных атлетов, чтобы общаться с вами. В общем\n" +
                    "веселуха, смешные люди, да. КОНЕЦ\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@&@&&#BBBBBBGBGGPPB###&&&&&&@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@&&&&&###BBBGBBBBG555B##BB####&&&&&@@@@@@@@@@\r\n@@@@@@@@@@@@@&&&&&&BGPB##BBGPGB#BBBBBBPYJ5PB###B#&@@@@@@@@@@\r\n@@@@@@@@@@@@&####BBBBBBBPGBGPBB5?7!!!!!~~?557J5Y5P#&&@@@@@@@\r\n@@@@@@@@@@@&BPBBGGB##GP5PBBBP?~~~!7?JYPP5?!?Y?7??YB&&&&&&#&@\r\n@@@@@@@@@&##BB&B5PBBYJG####Y!!7!7?JY5G###BB57PJ~!P#&#&##B&&B\r\n@@@@@@@@&&&BP&&P5GBPYB&&&#J?G~^^~!7?J555PP5P5?G5^?GBGGBB#&&&\r\n@@@@@@@&&&B#&#GPP5GPB&&&BJ~55!^~!!7??77~~~^~J7?5^!5BBBBB&&&&\r\n@@@@@@@&&B####BG5G#&&&BBY!:57^~7??J??7^.....7?GJ:~7YPPPGGB&&\r\n@@@@@@&@B####G5YPBBPGPYPY7^!7~77?~:.J&G^::^~7?PG!^!?YPPP5G&@\r\n@@@@@@&&B##BBGGPP5J777?YG5Y^^?YYYYY?5BGJ7JYYP&&&Y^7?JJJPB#&&\r\n@@@@&&BBBB##BB5PG5JJYY5G#G?::~~7J555555YJ?!7YB##G~?7??7YBBPB\r\n@@&&#PGBGBBBBGPGPPGBBPPP!:!GB?!!77?YPPJ77!!!?PB##Y?Y??5B###&\r\n@@&&#BB#BB5J55Y7:::^~~7Y?JG5!!7!!~7Y5J?G#B#G#G#&&&GP55G#B#&@\r\n@@@&&&BGBGJ7?YPPJ^.  .:^~J7:^!?7!^7JY?5##PPG5PGPGP5JYGG#&#@@\r\n@&&##P7~?PGGPYJ7?J!^. ..7?:..^!?77JY5G##Y!7?7JPGP?7^~YB#&&@@\r\nPJJJ5GGPY?YPB#BY^~JYY..!5?!^.:^!!7?Y555?~!?5PPG#Y!?~?P#&&@@@\r\n~7JJ?J?JYJYY~?5BP7^~YY!!GPJP~.^^~~!77~~!77?YPJJGB?!7PGB#&@@@\r\n^^^::^!!~^^^:^!?YPP::YY7YGGBBJ~^^^~!!77?J?5&@BYG#B??5&@&&&&&\r\n^:..::...   .^~~^^~..:!5GGB#B##GY!^^^~?7?G&@&Y##&&PG&@@@@&&&\r\n:........:^~~^:.  .. .:~?JJ5PPB#&&BJ~!~?Y?!~7G&&&@&#@@@@&@&&\r\n7^:^^~~!!!!~^:.....:^~~7~?JPP~^^~!7~.:.... .:G#&&@&&@@@&&&&&\r\nP!::^^~~!7!~:.:..:^:^~YB?5GGY..:.  .~~~^::.:7#&&&@@&&B#&&GGB\r\n&5~:.:^~~!!~^:^:::.^?B&&GY5PP~:~. :7P&&#Y??J#&&@@@@@#B#&@###\r\n&BY7:::~~!!~~~~^::?G&&&&&#GBBB~^!?BGP&#BGGP#&&&&@&@@&&#&@###\r\n?!:~^......:^~^^:?#B&&&&&&&######5#G#BB&BP5#&@@&&&&&&#B&&#B#\r\n7~^..       .:::~##5####&&&&&&&&&#GY#BB#BYY#&&&&&&&&B5G&&#GB\r\n:~^:.. . .. ..:~5&G?B#BBB#&&#####&5?####G7YB&&&&&&#BJ5G##BPG",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 55,
                    Text =
                    "   Вы присидаете и зажимаете с негива в дверь. Постреляв\n" +
                    "так чуть-чуть вы идёте посмотреть как вы расправились с\n" +
                    "этими зомбе. Вы открываете дверь.... а там скелеты!!!! Вы\n" +
                    "идёте на них, уже готовитесь стрелять! и вдруг резко\n" +
                    "понимаете как вам лень продолжать эту развилку этого сюжета\n" +
                    "в полноч перед сдачей проекта..... Поэтому решаете\n" +
                    "договорится со скелетами...\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@&5B@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@GJP&@@@5#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@#5PB7J@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@B!:~?B&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@#!~?~~^?PG&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@&!^^^^:^7J5#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@#Y~^...:^7JB@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@P!::.  .:~7P&@#B5P#@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@#?^:.. ..:??7#@&B55B@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@&G!.    . ~~YJG@&B@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@#:.~^:  :7^.:~~5&@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@&7 ~&@#G7 ..^^:...^7B@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@&JB@&Y^^^:.  .   ....^5&#@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@5^::::::~^     ........~#@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@G~::::::!PG#Y:      ...:::#@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@&!:::::~5&&&##J........ ..^G@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@B7^!G&@&&&&&^::JPJ^..... :#@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@&@@@@@@&&7.:.#@@&5~:. .:^~Y&@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@P?!~&@@@@&G&J......~P@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&57:..:....7B@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#7. ..::  .B@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@5    .^YG&@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@J .?#@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] {57},
                    ChoisesText = new string[]
                    {
                        "Пойти в суд нежити"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 56,
                    Text =
                    "   Зомбе вламываеются и идут в вашу сторону, вы\n" +
                    "отбрасываете пулемёт и говорите, что хотите мирно\n" +
                    "пообщаться. Зомбе продолжают идти в вашу сторону, вы\n" +
                    "говорите им, что вы не вкусный, но они не останавливаются.\n" +
                    "Тогда в даёте им аргумент, что ваша попытка с ними\n" +
                    "договорится сигнализирует о вашем низком интелекте и\n" +
                    "маленьком мозге. Вдруг зомбе останавливаются и\n" +
                    "задумываются.... \"Ладноа, идём пагаоврим в суде тагда\" -\n" +
                    "говорит один из них вам, ну и у вас нет выбора.\n\n" +
                    "@@@#G55J??J?7777777!!77!!!!!!!!!!!!!!!!!!!!!!!!!!77?7Y5P#@@@\r\n@#Y??JJJJJJJ?7???77!!!!!!!!!!!!!!!!!!!!!!~~!!!!!!77????J?Y#@\r\n#J?JJJJJJYYY????77!!~~^^~~~!~~~!!!!!!!!!!!~~!!!7?7J?77??7??#\r\nYJJYJJJJJJJ?7??^^~~~!!!!!!~:.:~!!!!!!!!!!!!!!!!!7?JJ???JJJJ5\r\nJJYYJJ?JJ???7!::7JJJJJYYYYJ7!:^!!!!!!!!!!!!!!!!!!7????YYJYYY\r\nYYYJJ???J??77^!YYJ???JJ55Y???7.:^~!!!!77777!!!!!!!7???JYYYJ?\r\nYYJJJJJJJJJ77^^JYJYYY?B@&&#?7?^.~!!!!777!7777!!!!!77JJJJYJ??\r\nYJJJJJJJJ??77^J&@P?J7?B@&&#7!7::!!!!!!!!!!!77!!!!77???JJJJJJ\r\nJJJJJJJJ??7!!!:!7?YJ???J?7!~^..:~!7!!!!!!!!!!!!!!!77??JYJJJJ\r\n??J?YJJY??!!!7!~!^?^^.:^!?7~::...:^!!!!!!!!!!77!!!7???J?J??J\r\n???J?77777777777!~?^..?!~7:~J^.:::..^!!!!77777777!!7??????JJ\r\n?JJ77777???77777!^^777!:...~?~::::....~7777777777!77????????\r\n????????????7!7!!!!~~!^. ..7J!:::..::..:!77777!!!!7777??????\r\n??????777777?J?~!!7777^ .:.:P7:::.:::::..:!7!!!!!7?777??????\r\n???7????77?7!!!~!!!JY7~.::. !Y::.::::::.. ~7!!!!77??????????\r\n777!77777??7!!!!7!~~~~!... ...::.:::::....!!!!~~!7?777777777\r\n!7!!!!!!!!!!!~~~~^~?77~.:.. ..:..^.::.....~~~~~~~~~~!!!!!!!!\r\n!!!!!!!!!!!!!!!~~~~~~~:.... .:.......:::..~~~~~~~~~!!!!!!!!!\r\n!!!!!!77!!777!!!~!~~~~^:~!~:~~^^... ..:...~~~~~~~~~~!!77!!!!\r\n77!!7777!!7!!~~~~!~!7~^~?!^7YJJ?:::. .~.:^~~~~~!~~~~!777!!!!\r\n!!!!7!~!!!777!7J?~~~^~^^!^!!.J?7!:...?7~:~~~!~~!~~!!7!!!!!!!\r\n!!!!!!!~!!77!??J?~!7~!7~~^^..:^~...^^^:~~:^:.~!!!~~!!!!!!!!!\r\n!!!!!!!!!7!!7??!~~!??!!~~^..:...........:....~!!~~~!!!!!!77J\r\n!!!!!!!777!!??7~!?!!!~^::. .. ... .::....... .^~~~~!!!!!!77?\r\n7!~!!!7777!!77~!77!~~^:..... ...........      :~~~~!!!!!7!~!\r\n#!!!!!!!!!!!!~~!?7~~~~^^:...........     ....:^~~~~~!!!!!!!#\r\n@B?!!!77777!~~!~7!~!?!~!~:::.............:::^~~~~~~~!!!!!?B@\r\n@@@#PYY7777!7JJ?!~~~!~~~~~~~^^^^^^^^^^^^^^~~~~~~~~~~~JY5B@@@",
                    ChoisesId = new int[] {57},
                    ChoisesText = new string[]
                    {
                        "Пойти в суд с зондбе"
                    }
                }
            ); context.DbEndMessages.AddRange(
                new EndMessage
                {
                    Id = 57,
                    EndId = 15,
                    Text =
                    "   Вы отправляетесь в суд и там люто спорите с на тему\n" +
                    "мозгов и можно ли вам с ними остаться или нет... Как вдруг\n" +
                    "в комноту заходит доктор зомбоз, а у него настолько большой\n" +
                    "мозг, что по сравнению с вашим, ну типо.... В общем он\n" +
                    "разрешил вам идти только с тем условием, что после смерти\n" +
                    "вы станете зондбе, ну а вы типо против шо-ли? нет. \"А\n" +
                    "потом ещё скелетом\" - добавляет он. Ну блин так имба\n" +
                    "получается скины на лайф фор фри, грэйт дил. И так вы\n" +
                    "договариваетесь, собираетесь уходить.... И вас убивают...\n" +
                    "Ну теперь вы зондбе, лол, ну ок, как раз скинчик затестите\n" +
                    "пайдёте, е. КОНЕЦ\n\n" +
                    "@@@@@@@@@@@@@@@@@@@@&#BBP5YYJ7JPG#&&@@@@@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@&P5P55P55555Y5YYGGYYYB@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@B55P#BGGGGPP55GGPPPBP??!J&@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@&JP#GB###BBGGPPGP55PGBBJ??7!P@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@B?5G#B&#&##BGGPP55G5YJ?5P77777~7P&@@@@@@@@@@@@@\r\n@@@@@@@@@@@&YJ5PBBB###BGGPPP55PPJ????5?????7::^?B@@@@@@@@@@@\r\n@@@@@@@@@&J^:PGGBGBBGGP5PP55555J????JJ??????~J~^^!G@@@@@@@@@\r\n@@@@@@@@5~::~?5P55555Y55Y5YYYYJ??????????777!&&P!^^!&@@@@@@@\r\n@@@@@@&!^:!#G!JJJJJJJJJJJJJ????????????????7^#@@&5^^:P@@@@@@\r\n@@@@@#~^.J@@&!77??????77?7?Y55YJ77??7777?JJ7G@@@@@B~~:Y@@@@@\r\n@@@@&^~.5@&@@??Y?!77!!7775PP5YYYJ7!7777777!B@@@@@@&#~~:5@@@@\r\n@@@@7~:7@&@&7JJY5Y????7J5JYPGBP~!!??7777!7#@&@@@@@@&B^~:#@@@\r\n@@@#^~:#&&@@B!G&#BYJYYY7Y&@#&@@?!J5Y777!5&&&&&&@@@@&&?~:7@@@\r\n@@@Y^:!&&@@@&G&@@@#^?J!!~#@@&&P??!7!!!~P&&&&&&&&&@@@&G^~^@@@\r\n@@@7~:J&&@@@@BB#BP!??575J~!??JYY777^!!~?5G&&&&&&&&@@&B^~:&@@\r\n@@@7~:?&&@@@@@&B!?YY55J?JY~75?^~?!~7J???JYYB&&&&&&&@&B^^:&@@\r\n@@@5^^!&&@@@&&&&#&B5##J7~~.75!~7!~!YY7#&P?YJG&&&&&&&&P^^^@@@\r\n@@@&:~:B&@@&&&&&&&&&&G?7?Y!?J7!!Y77J5BP&&B?YJ#&&&&&&#7~:J@@@\r\n@@@@?:^!#&@&&&&&&&&BGGBY77JYJ77PY75GP&&5&&B?YJ&&&&&&5~~:&@@@\r\n@@@@@~^^?#&&&&&#BBBGB5B&BGGG5?5J?7GP5&@GJ##5?JG&&&&G~~:G@@@@\r\n@@@@@&~^^7B&&&&GG####P?Y55?55?~~YPBY5?G#&#PYJ5J&&&5!~:P@@@@@\r\n@@@@@@@?^^~5&&&G?5B##&P~?YJ!J?~~!JJ#&5PBPJJ5PPJBB?~^^B@@@@@@\r\n@@@@@@@@G~^^!P&B?~?B###G7??J#57JY5YG##5J!?PPPPJ!~^:J@@@@@@@@\r\n@@@@@@@@@@P~^^!5GJ~!GBGGP5JG&&P!J5Y7555P##P5Y7~::7#@@@@@@@@@\r\n@@@@@@@@@@@@G7^:~7J5PBB##&&&&&&B7555@&&&&G?~::^J&@@@@@@@@@@@\r\n@@@@@@@@@@@@@@&P7^^^!?YPGB#####GP&G5G5?!^::^JB@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@#P?!^^^^^^^~^^^^^::^^!JG&@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@@@@&#BP55YYY5PGB&&@@@@@@@@@@@@@@@@@@@@@@",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {}
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 58,
                    Text =
                    "   Вы воскресаете, встаёте с земли... и вот вы на земле...\n" +
                    "но зачем вы сюда спускались? ваще хз.... Ну а рас если вы\n" +
                    "воскресли, то это значит, что вы исус 2? можно пойти\n" +
                    "распространять свою веру?.. хотя про это ведь другая\n" +
                    "концовка... Ну ладно... у меня мало времени, так что...\n\n" +
                    "J?????JY5G##G5YY55555PPPPGB##&@@@@@&#BBGPPPP555555PB##G5YJJJ\r\n#G???JJJYYPB##BGPPPPPPPGGGB#&&@@@@@&##BGGGPPPPPPG#&#BP5YYJJJ\r\n&#JJJJJJYYY5PB#&#BGGGGGB###&&@@@@@@&&##BBBGGGB#&&#BP55YYYYYY\r\n#G5PGPP555555PGB&&&#####&&&&&&@@@@&&&&&&####&&&#BGPP55555PPG\r\nYYY55YYJY5YPGGGBB#&&&&&&@B?^^!5#P!^:^J#@&&&&&&#BBGGGG555YYYY\r\n77???7777?JY5GGB###&&@@@J. :!JYPPP5J: ~&@@@&&####BGP5YJ?7777\r\n!77777????JY5PPGB#&&@@@?..^!J5PPGG#&&J.Y#&@@&&&#GGP55YJJ????\r\n77???JJYY555PPGBB#&@@&7..::.:~?G7^^7P&5~?YB@@&&#BGGPP555YYJJ\r\nGGGGBBBBBB###&&&&&&@B^ .^:...^P#!...:!P!!!!P@@&&&&&&####BBBB\r\n@@@@@@@@@@@@@@@@@@@#~. :~^~~^~YPBP5PGYP!^77~G@@@@@@@@@@@@@@@\r\n&&&&&&&&&&&&&&&@@@&~.  ~!!!!^.^~Y##&&&&G:.:^7#@@@&&&&&&&&&&#\r\nGPPPPPGGGBB###&&&@7.  .7!~^:.^~~7?5&&#BBJ  .!Y&&&&###BBBGGPP\r\nB5555PPPPGGB#&&@@B:    ^^..::^!J5J~?#BP57   ~75@&&#BGGGPPPPP\r\nGGGGGGGGB#&&@@&&&7    ....:~~~!?PBJ!YYJ?^   ..^&&&@&&#BGGGGG\r\nGGGGB#&&&&&&####&?:   ......:::^!7!!7!!~ ..:. !####&&&&&&#BB\r\nB##&&&&&##BBBBBB#B!              .::^^~: .!??7P#BBBBBB##&&&&\r\n&&&&#####BBBBB#BJ:      .  ..:...    :7. ~7~!?5##BBBBB######\r\n#########&###&&P^.      .:.:^^^:^7J!JP^. .:~7?75#&###&######\r\nBBBBB#BBB##&&&&#7.      ::::^~~~75GGG?:.  ...::~P&&&##BB##BB\r\nGGBBBB######&&#B5~      ::^^~!!~!YPPP!:. .^77:^JB&&#####BBBB\r\nBBGBB##BBBB#G?~^:..     .^^^^~!!!??J5!:.   .!:^^!Y5GBBBB#BBG\r\n######BBBBBB!:...:.     .:^^~~~!!~~JJ^:.  ....!^~!!75GBBBB##\r\nBBGBBGGBBBBG!:   .  ..^^^^!775J~^^YG5?!!!~:. ..^~!77YB#BBGBB\r\nYYYY5PGGGPYJ7~^~^^!7~JG#GP5PGG#P~7PG#&&&&#J!~!Y?5&BP#&&&&#BP\r\nJJY5P55YYY55Y5Y?J77PGJ5#&BGG#P5#B&&&&&&&&&&#&P&#J&&&Y#&&&&&&\r\nY5P5J?5PB##&PBBJ?J??GB?G&&BP&B5GB&@&B&&&&@&&#Y#&55&&B?#&&&&&\r\nPGY77JPPGBB#5P#5J?J?JBP?G&&B#&55G&@##&&&&@&&BJB&#J#&&G?&&&&&\r\nGY7JJ?P55GBPYY#PYJ?J?5&?JG&&&&P5P&@B&&&&&&&&BJP#&55&&&7P&&&&",
                    ChoisesId = new int[] {33},
                    ChoisesText = new string[]
                    {
                        "Создать новую веру"
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 59,
                    Text =
                    "   ",
                    ChoisesId = new int[] { },
                    ChoisesText = new string[]
                    {
                    }
                }
            ); context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 60,
                    Text =
                    "   ",
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