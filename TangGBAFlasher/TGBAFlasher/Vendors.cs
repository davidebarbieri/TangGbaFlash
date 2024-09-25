

namespace TGBAFlasher
{
    public static class Vendors
    {
        static Vendors()
        {
            codeToName = new Dictionary<string, string>();

            codeToName["00"] = "None";
            codeToName["01"] = "Nintendo";
            codeToName["08"] = "Capcom";
            codeToName["09"] = "HOT.B Co., Ltd";
            codeToName["0A"] = "Jaleco";
            codeToName["0B"] = "Coconuts";
            codeToName["0C"] = "Elite Systems/Coconuts"; 
            codeToName["13"] = "Electronic Arts";
            codeToName["18"] = "Hudson soft";
            codeToName["19"] = "B-AI/ITC Entertainment"; 
            codeToName["1A"] = "Yanoman";
            codeToName["1D"] = "Clary"; 
            codeToName["1F"] = "Virgin Games/7-UP"; 
            codeToName["20"] = "KSS"; 
            codeToName["22"] = "Pow"; 
            codeToName["24"] = "PCM Complete"; 
            codeToName["25"] = "San-X"; 
            codeToName["28"] = "Kotobuki/Walt disney/Kemco Japan"; 
            codeToName["29"] = "Seta";
            codeToName["2L"] = "Tamsoft"; 
            codeToName["30"] = "Infogrames/Viacom"; 
            codeToName["31"] = "Nintendo"; 
            codeToName["32"] = "Bandai"; 
            codeToName["33"] = "Ocean/Acclaim"; 
            codeToName["34"] = "Konami"; 
            codeToName["35"] = "Hector";
            codeToName["37"] = "Taito"; 
            codeToName["38"] = "Kotobuki systems/Interactive TV ent/Capcom/Hudson"; 
            codeToName["39"] = "Telstar/Accolade/Banpresto"; 
            codeToName["3C"] = "Entertainment int./Empire/Twilight"; 
            codeToName["3E"] = "Gremlin Graphics/Chup Chup"; 
            codeToName["41"] = "Ubisoft"; 
            codeToName["42"] = "Atlus"; 
            codeToName["44"] = "Malibu"; 
            codeToName["47"] = "Spectrum Holobyte/Bullet Proof"; 
            codeToName["46"] = "Angel"; 
            codeToName["49"] = "Irem";
            codeToName["4A"] = "Virgin"; 
            codeToName["4D"] = "Malibu (T-HQ)";
            codeToName["4F"] = "U.S. Gold";
            codeToName["4J"] = "Fox Interactive/Probe"; 
            codeToName["4K"] = "Time Warner"; 
            codeToName["4S"] = "Black Pearl (T-HQ)";
            codeToName["50"] = "Absolute Entertainment";
            codeToName["51"] = "Acclaim";
            codeToName["52"] = "Activision";
            codeToName["53"] = "American Sammy"; 
            codeToName["54"] = "Gametek/Infogenius Systems/Konami"; 
            codeToName["55"] = "Hi Tech Expressions/Park Place";
            codeToName["56"] = "LJN. Toys Ltd";
            codeToName["57"] = "Matchbox International"; 
            codeToName["58"] = "Mattel"; 
            codeToName["59"] = "Milton Bradley"; 
            codeToName["5A"] = "Mindscape";
            codeToName["5B"] = "ROMStar";
            codeToName["5C"] = "Taxan/Naxat soft";
            codeToName["5D"] = "Williams/Tradewest/Rare"; 
            codeToName["60"] = "Titus";
            codeToName["61"] = "Virgin Interactive";
            codeToName["64"] = "LucasArts"; 
            codeToName["67"] = "Ocean";
            codeToName["69"] = "Electronic Arts";
            codeToName["6E"] = "Elite Systems";
            codeToName["6F"] = "Electro brain";
            codeToName["70"] = "Infogrames";
            codeToName["71"] = "Interplay productions";
            codeToName["72"] = "First Star Software/Broderbund"; 
            codeToName["73"] = "Sculptured software"; 
            codeToName["75"] = "The sales curve Ltd./SCi Entertainment Group"; 
            codeToName["78"] = "T-HQ Inc.";
            codeToName["79"] = "Accolade";
            codeToName["7A"] = "Triffix Ent. Inc."; 
            codeToName["7C"] = "MicroProse/NMS"; 
            codeToName["7D"] = "Universal Interactive Studios"; 
            codeToName["7F"] = "Kotobuki Systems/Kemco"; 
            codeToName["80"] = "Misawa/NMS"; 
            codeToName["83"] = "LOZC/G.Amusements"; 
            codeToName["86"] = "Zener Works/Tokuna Shoten"; 
            codeToName["87"] = "Tsukuda Original"; 
            codeToName["8B"] = "Bullet-Proof software";
            codeToName["8C"] = "Vic Tokai";
            codeToName["8E"] = "Character soft/Sanrio/APE"; 
            codeToName["8F"] = "I'Max";
            codeToName["8M"] = "CyberFront/Taito"; 
            codeToName["91"] = "Chun Soft"; 
            codeToName["92"] = "Video System"; 
            codeToName["93"] = "Bec/Tsuburava/Ocean/Acclaim"; 
            codeToName["95"] = "Varie";
            codeToName["96"] = "Yonesawa/S'Pal"; 
            codeToName["97"] = "Kaneko"; 
            codeToName["99"] = "Pack-In-Video/ARC";
            codeToName["9A"] = "Nihon Bussan"; 
            codeToName["9B"] = "Tecmo";
            codeToName["9C"] = "Imagineer Co.,  Ltd";
            codeToName["9D"] = "Banpresto"; 
            codeToName["9F"] = "Namco/Nova"; 
            codeToName["A1"] = "Hori electric"; 
            codeToName["A2"] = "Bandai"; 
            codeToName["A4"] = "Konami";
            codeToName["A6"] = "Kawada"; 
            codeToName["A7"] = "Takara";
            codeToName["A9"] = "Technos japan Corp.";
            codeToName["AA"] = "First Star software/Broderbund/dB soft"; 
            codeToName["AC"] = "Toei";
            codeToName["AD"] = "TOHO Co.,  Ltd."; 
            codeToName["AF"] = "Namco hometek";
            codeToName["AG"] = "Playmates/Shiny"; 
            codeToName["AL"] = "MediaFactory"; 
            codeToName["B0"] = "Acclaim/LJN"; 
            codeToName["B1"] = "Nexoft/ASCII"; 
            codeToName["B2"] = "Bandai";
            codeToName["B4"] = "Enix";
            codeToName["B6"] = "HAL";
            codeToName["B7"] = "SNK (america)";
            codeToName["B9"] = "Pony Canyon";
            codeToName["BA"] = "Culture Brain";
            codeToName["BB"] = "SunSoft";
            codeToName["BD"] = "Sony Imagesoft";
            codeToName["BF"] = "Sammy";
            codeToName["BL"] = "MTO Inc."; 
            codeToName["C0"] = "Taito";
            codeToName["C2"] = "Kemco";
            codeToName["C3"] = "SquareSoft";
            codeToName["C4"] = "Tokuma Shoten";
            codeToName["C5"] = "Data East";
            codeToName["C6"] = "Tonkin House";
            codeToName["C8"] = "Koei";
            codeToName["C9"] = "UPL Comp. Ltd"; 
            codeToName["CA"] = "Ultra games/konami";
            codeToName["CB"] = "Vap Inc.";
            codeToName["CC"] = "USE Co.,  Ltd"; 
            codeToName["CD"] = "Meldac";
            codeToName["CE"] = "FCI/Pony Canyon";
            codeToName["CF"] = "Angel Co.";
            codeToName["D0"] = "Taito"; 
            codeToName["D1"] = "Sofel";
            codeToName["D2"] = "Quest";
            codeToName["D3"] = "Sigma Enterprises";
            codeToName["D4"] = "Lenar/Ask kodansha"; 
            codeToName["D6"] = "Naxat soft";
            codeToName["D7"] = "Copya system"; 
            codeToName["D9"] = "Banpresto";
            codeToName["DA"] = "Tomy";
            codeToName["DB"] = "Hiro/LJN"; 
            codeToName["DD"] = "NCS/Masiya"; 
            codeToName["DE"] = "Human";
            codeToName["DF"] = "Altron";
            codeToName["DK"] = "Kodansha"; 
            codeToName["E0"] = "KK DCE/Yaleco"; 
            codeToName["E1"] = "Towachiki";
            codeToName["E2"] = "Yutaka";
            codeToName["E3"] = "Varie"; 
            codeToName["E4"] = "T&E SOFT"; 
            codeToName["E5"] = "Epoch";
            codeToName["E7"] = "Athena";
            codeToName["E8"] = "Asmik";
            codeToName["E9"] = "Natsume";
            codeToName["EA"] = "King Records/A Wave"; 
            codeToName["EB"] = "Altus";
            codeToName["EC"] = "Epic/Sony Records";
            codeToName["EE"] = "IGS Corp";
            codeToName["EJ"] = "Virgin";
            codeToName["F0"] = "A Wave/Accolade"; 
            codeToName["F3"] = "Extreme Entertainment/Malibu int."; 
            codeToName["FB"] = "Psycnosis"; 
            codeToName["FF"] = "LJN";
            codeToName["GD"] = "Square Enix";
        }


    public static string CodeToName(string makerString)
    {
        if (codeToName.TryGetValue(makerString, out var name))
            return name;

        return "Unknown";
    }

    static Dictionary<string, string> codeToName;
}
}
