﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken
{
    /// <summary>
    /// https://api.kraken.com/0/public/Depth?pair=btceur&count=100
    /// </summary>
    public class DepthResponse : KrakenResponse
    {
        public override Data.IMarketData ToMarketData()
        {
            throw new NotImplementedException();
        }
    }
}
//{"error":[],"result":{"XXBTZEUR":{"asks":[["210.99990","9.401",1429453843],["211.00000","0.840",1429452815],["211.11129","3.106",1429448156],["211.14000","0.010",1429453847],["211.27000","35.000",1429453787],["211.30000","0.110",1429448056],["211.35000","4.949",1429453075],["211.40000","0.010",1429448049],["211.47000","0.200",1429435564],["211.49197","11.433",1429417708],["211.50000","8.100",1429447925],["211.60000","0.020",1429447920],["211.64000","0.020",1429453433],["211.65000","0.010",1429451931],["211.66000","0.010",1429451891],["211.70000","0.320",1429447794],["211.80000","0.030",1429447786],["211.84921","4.000",1429453803],["211.84923","5.000",1429450333],["211.84998","4.000",1429453803],["211.85000","24.800",1429441672],["211.87332","4.000",1429453852],["211.87334","9.583",1429417707],["211.90000","0.020",1429447663],["212.00000","59.916",1429450995],["212.10000","0.078",1429447529],["212.20000","0.378",1429453203],["212.24504","1.000",1429435117],["212.25539","11.667",1429417706],["212.30000","0.078",1429431018],["212.39000","0.800",1429453881],["212.40000","5.078",1429388275],["212.47700","0.200",1429250779],["212.50000","5.582",1429448484],["212.57000","0.010",1429441084],["212.58000","5.000",1429453363],["212.60000","0.078",1429410686],["212.63813","10.221",1429417705],["212.70000","0.078",1429440389],["212.80000","1.078",1429445247],["212.90000","0.078",1429441515],["213.00000","0.448",1429443129],["213.02156","9.619",1429417704],["213.03320","2.526",1429453847],["213.24999","1.072",1429453858],["213.25000","0.020",1429453844],["213.26000","0.010",1429453847],["213.37000","0.033",1429452443],["213.40569","8.655",1429417703],["213.48000","0.010",1429436191],["213.48400","0.200",1429247598],["213.50000","1.100",1429448502],["213.59009","20.000",1429307034],["213.68052","0.800",1429453785],["213.79052","6.095",1429428474],["213.96574","0.013",1429381228],["213.99990","20.000",1429228700],["214.00000","1.147",1429417129],["214.12764","2.000",1429275075],["214.17604","6.683",1429430036],["214.20000","9.728",1429453309],["214.26000","4.000",1429431737],["214.30000","1.000",1429269763],["214.39000","0.410",1429432204],["214.40000","5.000",1429453287],["214.49100","0.200",1429227653],["214.50000","0.300",1429262331],["214.56226","10.298",1429430149],["214.59838","1.000",1429450340],["214.75000","3.315",1429249353],["214.88357","0.445",1429266045],["214.94917","8.043",1429430237],["215.00000","26.303",1429450528],["215.04070","0.194",1429453667],["215.30000","0.010",1429274980],["215.33678","7.159",1429433965],["215.49800","0.200",1428969645],["215.50000","0.300",1429242903],["215.68432","0.011",1429381224],["215.72509","2.512",1429435268],["215.80000","1.863",1429262260],["215.97000","0.024",1429211265],["216.00000","9.910",1429272872],["216.11410","6.173",1429446118],["216.16924","0.013",1429382394],["216.21000","0.010",1429275031],["216.50381","2.292",1429452764],["216.50500","0.200",1428950103],["216.61000","3.054",1429452366],["216.89422","5.883",1429453611],["217.00000","34.215",1429268183],["217.05000","0.100",1429212913],["217.28534","6.637",1429453764],["217.36315","0.064",1428964070],["217.51200","0.200",1428948711],["218.00000","9.900",1429170537],["218.01000","25.000",1429263828],["218.51900","0.200",1428948647],["219.00000","11.380",1429214795],["219.52600","0.200",1428948648]],"bids":[["210.16000","0.510",1429453887],["210.09000","0.010",1429453648],["210.01000","0.053",1429453123],["209.98002","7.229",1429453887],["209.98000","0.800",1429453881],["209.88504","9.990",1429453751],["209.87000","0.010",1429453849],["209.74000","0.010",1429453845],["209.70670","2.503",1429453847],["209.58000","0.010",1429453747],["209.50793","11.662",1429452578],["209.20000","0.500",1429453844],["209.15000","1.000",1429452952],["209.13150","8.412",1429430807],["209.10000","0.800",1429453872],["209.09000","4.405",1429453882],["208.99000","0.020",1429453849],["208.92096","2.000",1429453868],["208.91096","2.400",1429453797],["208.90003","0.220",1429439177],["208.75574","7.708",1429430781],["208.70000","0.020",1429447922],["208.60000","0.058",1429447923],["208.50000","0.020",1429447928],["208.40000","0.020",1429433983],["208.38067","0.250",1429439180],["208.38066","7.331",1429430207],["208.36000","11.352",1429452943],["208.30000","0.020",1429434030],["208.28423","8.390",1429453797],["208.00625","9.120",1429430231],["207.93765","5.000",1429444120],["207.70328","0.384",1429453885],["207.70327","2.000",1429453877],["207.70000","0.300",1429440709],["207.63254","0.010",1429444684],["207.63253","0.300",1429439209],["207.63252","11.644",1429429974],["207.50000","1.000",1429441638],["207.25946","7.800",1429428950],["207.00000","1.697",1429448574],["206.88708","0.330",1429439241],["206.88707","7.261",1429427768],["206.72210","32.140",1429453798],["206.60000","0.300",1429452007],["206.51535","8.271",1429417715],["206.40000","0.300",1429452256],["206.20000","3.000",1429437713],["206.14431","0.350",1429439286],["206.14430","9.570",1429417714],["206.10000","7.000",1429437715],["206.00500","0.500",1429386477],["206.00001","5.000",1429385774],["206.00000","0.115",1429452699],["205.95000","5.000",1429433617],["205.90003","4.000",1429453872],["205.90001","5.000",1429385753],["205.85992","4.000",1429453873],["205.85990","8.400",1429374052],["205.80000","0.300",1429437722],["205.77393","4.000",1429453811],["205.77391","8.930",1429417713],["205.74846","2.431",1429216247],["205.69000","0.244",1429441954],["205.64641","0.400",1429439315],["205.64640","17.926",1429263332],["205.50000","0.300",1429392351],["205.40419","9.123",1429417712],["205.40000","0.010",1429431005],["205.39021","0.193",1429453878],["205.29100","10.000",1429267187],["205.17000","3.200",1429452366],["205.16000","0.258",1429392725],["205.12000","0.062",1429390008],["205.11000","4.870",1429428280],["205.03514","0.440",1429439366],["205.03513","8.997",1429417711],["205.00000","13.860",1429450132],["204.99990","21.900",1429426746],["204.66673","7.999",1429417710],["204.60000","2.000",1429392036],["204.50000","10.915",1429375452],["204.29900","11.884",1429417709],["204.13570","2.000",1429041500],["204.10000","0.245",1429379319],["204.03599","1.500",1429131420],["204.00000","15.225",1429379319],["203.93193","9.638",1429417708],["203.91792","4.904",1429133245],["203.60000","0.010",1429392136],["203.56552","11.684",1429417707],["203.43999","4.900",1429286773],["203.19977","7.728",1429417706],["203.00000","15.010",1429380192],["202.83466","10.038",1429449850],["202.70000","0.010",1429273419],["202.65000","0.050",1429033270],["202.59042","0.258",1424088336],["202.50000","1.920",1429041468],["202.38999","0.248",1428705874]]}}}