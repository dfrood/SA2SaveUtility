using System;
using System.Collections.Generic;
using System.Linq;

namespace SA2SaveUtility
{
    public class Checksum
    {
        public static void WriteChaoChecksum(byte[] a1, bool isSA2)
        {
            Random rand = new Random();
            int off = isSA2 ? 0x24C : 0;
            a1[51229 + off] = 0;
            a1[51224 + off] = 0;
            a1[51231 + off] = 0;
            a1[51226 + off] = 0;
            a1[51227 + off] = 0;
            a1[51225 + off] = (byte)BitConverter.DoubleToInt64Bits(rand.NextDouble() * 0.000030517578125 * 255.9998931884766);
            a1[51228 + off] = (byte)BitConverter.DoubleToInt64Bits(rand.NextDouble() * 0.000030517578125 * 255.9998931884766);
            a1[51230 + off] = (byte)BitConverter.DoubleToInt64Bits(rand.NextDouble() * 0.000030517578125 * 255.9998931884766);
            uint v1 = sub_7172B0(51232 + off, a1);
            a1[51229 + off] = (byte)v1;
            a1[51224 + off] = (byte)(v1 >> 8);
            a1[51231 + off] = (byte)(v1 >> 16);
            a1[51226 + off] = (byte)(v1 >> 24);
            a1[51227 + off] = (byte)BitConverter.DoubleToInt64Bits(rand.NextDouble() * 0.000030517578125 * 255.9998931884766);
        }

        static uint sub_7172B0(int length, byte[] data)
        {
            return sub_721B10(data, length, 0x6368616Fu, 0x686F6765u);
        }


        static uint[] dword_884D98 = new uint[] {
            0, 0x0C9073096, 0x920E612C, 0x0A50951BA, 0x0FF6DC419, 0x0CA6AF48F,
            0x9163A535, 0x0A66495A3, 0x0FEDB8832, 0x0CFDCB8A4, 0x94D5E91E,
            0x0A3D2D988, 0x0F9B64C2B, 0x0CCB17CBD, 0x97B82D07, 0x0A0BF1D91,
            0x0FDB71064, 0x0C4B020F2, 0x9FB97148, 0x0A8BE41DE, 0x0F2DAD47D,
            0x0C7DDE4EB, 0x9CD4B551, 0x0ABD385C7, 0x0F36C9856, 0x0C26BA8C0,
            0x9962F97A, 0x0AE65C9EC, 0x0F4015C4F, 0x0C1066CD9, 0x9A0F3D63,
            0x0AD080DF5, 0x0FB6E20C8, 0x0D269105E, 0x896041E4, 0x0BE677172,
            0x0E403E4D1, 0x0D104D447, 0x8A0D85FD, 0x0BD0AB56B, 0x0E5B5A8FA,
            0x0D4B2986C, 0x8FBBC9D6, 0x0B8BCF940, 0x0E2D86CE3, 0x0D7DF5C75,
            0x8CD60DCF, 0x0BBD13D59, 0x0E6D930AC, 0x0DFDE003A, 0x84D75180,
            0x0B3D06116, 0x0E9B4F4B5, 0x0DCB3C423, 0x87BA9599, 0x0B0BDA50F,
            0x0E802B89E, 0x0D9058808, 0x820CD9B2, 0x0B50BE924, 0x0EF6F7C87,
            0x0DA684C11, 0x81611DAB, 0x0B6662D3D, 0x0F6DC4190, 0x0FFDB7106,
            0x0A4D220BC, 0x93D5102A, 0x0C9B18589, 0x0FCB6B51F, 0x0A7BFE4A5,
            0x90B8D433, 0x0C807C9A2, 0x0F900F934, 0x0A209A88E, 0x950E9818,
            0x0CF6A0DBB, 0x0FA6D3D2D, 0x0A1646C97, 0x96635C01, 0x0CB6B51F4,
            0x0F26C6162, 0x0A96530D8, 0x9E62004E, 0x0C40695ED, 0x0F101A57B,
            0x0AA08F4C1, 0x9D0FC457, 0x0C5B0D9C6, 0x0F4B7E950, 0x0AFBEB8EA,
            0x98B9887C, 0x0C2DD1DDF, 0x0F7DA2D49, 0x0ACD37CF3, 0x9BD44C65,
            0x0CDB26158, 0x0E4B551CE, 0x0BFBC0074, 0x88BB30E2, 0x0D2DFA541,
            0x0E7D895D7, 0x0BCD1C46D, 0x8BD6F4FB, 0x0D369E96A, 0x0E26ED9FC,
            0x0B9678846, 0x8E60B8D0, 0x0D4042D73, 0x0E1031DE5, 0x0BA0A4C5F,
            0x8D0D7CC9, 0x0D005713C, 0x0E90241AA, 0x0B20B1010, 0x850C2086,
            0x0DF68B525, 0x0EA6F85B3, 0x0B166D409, 0x8661E49F, 0x0DEDEF90E,
            0x0EFD9C998, 0x0B4D09822, 0x83D7A8B4, 0x0D9B33D17, 0x0ECB40D81,
            0x0B7BD5C3B, 0x80BA6CAD, 0x0EDB88320, 0x0A4BFB3B6, 0x0FFB6E20C,
            0x0C8B1D29A, 0x92D54739, 0x0A7D277AF, 0x0FCDB2615, 0x0CBDC1683,
            0x93630B12, 0x0A2643B84, 0x0F96D6A3E, 0x0CE6A5AA8, 0x940ECF0B,
            0x0A109FF9D, 0x0FA00AE27, 0x0CD079EB1, 0x900F9344, 0x0A908A3D2,
            0x0F201F268, 0x0C506C2FE, 0x9F62575D, 0x0AA6567CB, 0x0F16C3671,
            0x0C66B06E7, 0x9ED41B76, 0x0AFD32BE0, 0x0F4DA7A5A, 0x0C3DD4ACC,
            0x99B9DF6F, 0x0ACBEEFF9, 0x0F7B7BE43, 0x0C0B08ED5, 0x96D6A3E8,
            0x0BFD1937E, 0x0E4D8C2C4, 0x0D3DFF252, 0x89BB67F1, 0x0BCBC5767,
            0x0E7B506DD, 0x0D0B2364B, 0x880D2BDA, 0x0B90A1B4C, 0x0E2034AF6,
            0x0D5047A60, 0x8F60EFC3, 0x0BA67DF55, 0x0E16E8EEF, 0x0D669BE79,
            0x8B61B38C, 0x0B266831A, 0x0E96FD2A0, 0x0DE68E236, 0x840C7795,
            0x0B10B4703, 0x0EA0216B9, 0x0DD05262F, 0x85BA3BBE, 0x0B4BD0B28,
            0x0EFB45A92, 0x0D8B36A04, 0x82D7FFA7, 0x0B7D0CF31, 0x0ECD99E8B,
            0x0DBDEAE1D, 0x9B64C2B0, 0x9263F226, 0x0C96AA39C, 0x0FE6D930A,
            0x0A40906A9, 0x910E363F, 0x0CA076785, 0x0FD005713, 0x0A5BF4A82,
            0x94B87A14, 0x0CFB12BAE, 0x0F8B61B38, 0x0A2D28E9B, 0x97D5BE0D,
            0x0CCDCEFB7, 0x0FBDBDF21, 0x0A6D3D2D4, 0x9FD4E242, 0x0C4DDB3F8,
            0x0F3DA836E, 0x0A9BE16CD, 0x9CB9265B, 0x0C7B077E1, 0x0F0B74777,
            0x0A8085AE6, 0x990F6A70, 0x0C2063BCA, 0x0F5010B5C, 0x0AF659EFF,
            0x9A62AE69, 0x0C16BFFD3, 0x0F66CCF45, 0x0A00AE278, 0x890DD2EE,
            0x0D2048354, 0x0E503B3C2, 0x0BF672661, 0x8A6016F7, 0x0D169474D,
            0x0E66E77DB, 0x0BED16A4A, 0x8FD65ADC, 0x0D4DF0B66, 0x0E3D83BF0,
            0x0B9BCAE53, 0x8CBB9EC5, 0x0D7B2CF7F, 0x0E0B5FFE9, 0x0BDBDF21C,
            0x84BAC28A, 0x0DFB39330, 0x0E8B4A3A6, 0x0B2D03605, 0x87D70693,
            0x0DCDE5729, 0x0EBD967BF, 0x0B3667A2E, 0x82614AB8, 0x0D9681B02,
            0x0EE6F2B94, 0x0B40BBE37, 0x810C8EA1, 0x0DA05DF1B, 0x0ED02EF8D };

        static uint sub_721B10(byte[] data, int length, uint a3, uint a4)
        {
            uint v4; // eax@1
            int v5; // edx@1
            int v6; // ecx@2

            v5 = length;
            v4 = a3;
            if (length > 0)
            {
                v6 = 0;
                do
                {
                    v4 = dword_884D98[data[v6++] ^ (byte)v4] ^ ((uint)v4 >> 8);
                    --v5;
                }
                while (v5 > 0);
            }
            return a4 ^ v4;
        }

        public static byte[] WriteMainChecksum(byte[] save, bool PC, bool GC, bool PS3)
        {
            byte[] checksum = new byte[4];
            List<byte> newSave = new List<byte>();

            if (PC || GC)
            {
                if (PC) { checksum = BitConverter.GetBytes(save.Skip(0x2844).ToArray().Select(x => (int)x).Sum()); }
                if (GC) { checksum = BitConverter.GetBytes(save.Skip(0x2844).ToArray().Select(x => (int)x).Sum()).Reverse().ToArray(); }
                newSave.AddRange(save.Take(0x2840).ToArray());
                newSave.AddRange(checksum);
                newSave.AddRange(save.Skip(0x2844).ToArray());
            }
            if (!PC && !GC)
            {
                if (!PS3)
                {
                    foreach (byte[] splitSave in Main.SplitByteArray(save, 0x6004))
                    {
                        checksum = BitConverter.GetBytes(splitSave.Skip(0x2848).ToArray().Select(x => (int)x).Sum()).Reverse().ToArray();
                        newSave.AddRange(splitSave.Take(0x2844).ToArray());
                        newSave.AddRange(checksum);
                        newSave.AddRange(splitSave.Skip(0x2848).ToArray());
                    }
                }
                else
                {
                    foreach (byte[] splitSave in Main.SplitByteArray(save, 0x6008))
                    {
                        checksum = BitConverter.GetBytes(splitSave.Skip(0x284C).ToArray().Select(x => (int)x).Sum()).Reverse().ToArray();
                        newSave.AddRange(splitSave.Take(0x2848).ToArray());
                        newSave.AddRange(checksum);
                        newSave.AddRange(splitSave.Skip(0x284C).ToArray());
                    }
                }
            }


            return newSave.ToArray();
        }

    }
}
