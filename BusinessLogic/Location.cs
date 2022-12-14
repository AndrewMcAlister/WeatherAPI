using System.Security.Authentication;
using WeatherTypes.Models;

namespace WeatherAPI.BusinessLogic
{
    public static class Locations
    {
        public static List<Country> Countries
        {
            get
            { 
                return new List<Country>()
                {
                    new Country() { Name="Afghanistan",Cities = new List<City>(){new City() { Name="Kabul", IsCapital=true} } },
                    new Country() { Name="Albania",Cities = new List<City>(){new City() { Name="Tirana", IsCapital=true} } },
                    new Country() { Name="Algeria",Cities = new List<City>(){new City() { Name="Algiers", IsCapital=true} } },
                    new Country() { Name="American Samoa",Cities = new List<City>(){new City() { Name="Pago Pago", IsCapital=true} } },
                    new Country() { Name="Andorra",Cities = new List<City>(){new City() { Name="Andorra la Vella", IsCapital=true} } },
                    new Country() { Name="Angola",Cities = new List<City>(){new City() { Name="Luanda", IsCapital=true} } },
                    new Country() { Name="Anguilla",Cities = new List<City>(){new City() { Name="The Valley", IsCapital=true} } },
                    new Country() { Name="Antigua and Barbuda",Cities = new List<City>(){new City() { Name="Saint John's", IsCapital=true} } },
                    new Country() { Name="Argentina",Cities = new List<City>(){new City() { Name="Buenos Aires", IsCapital=true} } },
                    new Country() { Name="Armenia",Cities = new List<City>(){new City() { Name="Yerevan", IsCapital=true} } },
                    new Country() { Name="Aruba",Cities = new List<City>(){new City() { Name="Oranjestad", IsCapital=true} } },
                    new Country() { Name="Australia",Cities = new List<City>(){new City() { Name="Canberra", IsCapital=true} } },
                    new Country() { Name="Austria",Cities = new List<City>(){new City() { Name="Vienna", IsCapital=true} } },
                    new Country() { Name="Azerbaijan",Cities = new List<City>(){new City() { Name="Baku", IsCapital=true} } },
                    new Country() { Name="Bahamas",Cities = new List<City>(){new City() { Name="Nassau", IsCapital=true} } },
                    new Country() { Name="Bahrain",Cities = new List<City>(){new City() { Name="Manama", IsCapital=true} } },
                    new Country() { Name="Bangladesh",Cities = new List<City>(){new City() { Name="Dhaka", IsCapital=true} } },
                    new Country() { Name="Barbados",Cities = new List<City>(){new City() { Name="Bridgetown", IsCapital=true} } },
                    new Country() { Name="Belarus",Cities = new List<City>(){new City() { Name="Minsk", IsCapital=true} } },
                    new Country() { Name="Belgium",Cities = new List<City>(){new City() { Name="Brussels", IsCapital=true} } },
                    new Country() { Name="Belize",Cities = new List<City>(){new City() { Name="Belmopan", IsCapital=true} } },
                    new Country() { Name="Benin",Cities = new List<City>(){new City() { Name="Porto-Novo", IsCapital=true} } },
                    new Country() { Name="Bermuda",Cities = new List<City>(){new City() { Name="Hamilton", IsCapital=true} } },
                    new Country() { Name="Bhutan",Cities = new List<City>(){new City() { Name="Thimphu", IsCapital=true} } },
                    new Country() { Name="Bolivia",Cities = new List<City>(){new City() { Name="Sucre", IsCapital=true} } },
                    new Country() { Name="Bolivia",Cities = new List<City>(){new City() { Name="La Paz", IsCapital=true} } },
                    new Country() { Name="Bosnia and Herzegovina",Cities = new List<City>(){new City() { Name="Sarajevo", IsCapital=true} } },
                    new Country() { Name="Botswana",Cities = new List<City>(){new City() { Name="Gaborone", IsCapital=true} } },
                    new Country() { Name="Brazil",Cities = new List<City>(){new City() { Name="Brasilia", IsCapital=true} } },
                    new Country() { Name="Brunei Darussalam",Cities = new List<City>(){new City() { Name="Bandar Seri Begawan", IsCapital=true} } },
                    new Country() { Name="Bulgaria",Cities = new List<City>(){new City() { Name="Sofia", IsCapital=true} } },
                    new Country() { Name="Burkina Faso",Cities = new List<City>(){new City() { Name="Ouagadougou", IsCapital=true} } },
                    new Country() { Name="Burundi",Cities = new List<City>(){new City() { Name="Bujumbura", IsCapital=true} } },
                    new Country() { Name="Cabo Verde",Cities = new List<City>(){new City() { Name="Praia", IsCapital=true} } },
                    new Country() { Name="Cambodia",Cities = new List<City>(){new City() { Name="Phnom Penh", IsCapital=true} } },
                    new Country() { Name="Cameroon",Cities = new List<City>(){new City() { Name="Yaounde", IsCapital=true} } },
                    new Country() { Name="Canada",Cities = new List<City>(){new City() { Name="Ottawa", IsCapital=true} } },
                    new Country() { Name="Central African Republic",Cities = new List<City>(){new City() { Name="Bangui", IsCapital=true} } },
                    new Country() { Name="Chad",Cities = new List<City>(){new City() { Name="N'Djamena", IsCapital=true} } },
                    new Country() { Name="Chile",Cities = new List<City>(){new City() { Name="Santiago", IsCapital=true} } },
                    new Country() { Name="China",Cities = new List<City>(){new City() { Name="Beijing", IsCapital=true} } },
                    new Country() { Name="Colombia",Cities = new List<City>(){new City() { Name="Bogota", IsCapital=true} } },
                    new Country() { Name="Comoros",Cities = new List<City>(){new City() { Name="Moroni", IsCapital=true} } },
                    new Country() { Name="Costa Rica",Cities = new List<City>(){new City() { Name="San Jose", IsCapital=true} } },
                    new Country() { Name="Croatia",Cities = new List<City>(){new City() { Name="Zagreb", IsCapital=true} } },
                    new Country() { Name="Cuba",Cities = new List<City>(){new City() { Name="Havana", IsCapital=true} } },
                    new Country() { Name="Curaçao",Cities = new List<City>(){new City() { Name="Willemstad", IsCapital=true} } },
                    new Country() { Name="Cyprus",Cities = new List<City>(){new City() { Name="Nicosia", IsCapital=true} } },
                    new Country() { Name="Czechia",Cities = new List<City>(){new City() { Name="Prague", IsCapital=true} } },
                    new Country() { Name="Côte d'Ivoire",Cities = new List<City>(){new City() { Name="Yamoussoukro", IsCapital=true} } },
                    new Country() { Name="Democratic Republic of the Congo",Cities = new List<City>(){new City() { Name="Kinshasa", IsCapital=true} } },
                    new Country() { Name="Denmark",Cities = new List<City>(){new City() { Name="Copenhagen", IsCapital=true} } },
                    new Country() { Name="Djibouti",Cities = new List<City>(){new City() { Name="Djibouti", IsCapital=true} } },
                    new Country() { Name="Dominica",Cities = new List<City>(){new City() { Name="Roseau", IsCapital=true} } },
                    new Country() { Name="Dominican Republic",Cities = new List<City>(){new City() { Name="Santo Domingo", IsCapital=true} } },
                    new Country() { Name="Ecuador",Cities = new List<City>(){new City() { Name="Quito", IsCapital=true} } },
                    new Country() { Name="Egypt",Cities = new List<City>(){new City() { Name="Cairo", IsCapital=true} } },
                    new Country() { Name="El Salvador",Cities = new List<City>(){new City() { Name="San Salvador", IsCapital=true} } },
                    new Country() { Name="Equatorial Guinea",Cities = new List<City>(){new City() { Name="Malabo", IsCapital=true} } },
                    new Country() { Name="Eritrea",Cities = new List<City>(){new City() { Name="Asmara", IsCapital=true} } },
                    new Country() { Name="Estonia",Cities = new List<City>(){new City() { Name="Tallinn", IsCapital=true} } },
                    new Country() { Name="Eswatini",Cities = new List<City>(){new City() { Name="Lobamba", IsCapital=true} } },
                    new Country() { Name="Eswatini",Cities = new List<City>(){new City() { Name="Mbabane", IsCapital=true} } },
                    new Country() { Name="Ethiopia",Cities = new List<City>(){new City() { Name="Addis Ababa", IsCapital=true} } },
                    new Country() { Name="Fiji",Cities = new List<City>(){new City() { Name="Suva", IsCapital=true} } },
                    new Country() { Name="Finland",Cities = new List<City>(){new City() { Name="Helsinki", IsCapital=true} } },
                    new Country() { Name="France",Cities = new List<City>(){new City() { Name="Paris", IsCapital=true} } },
                    new Country() { Name="Gabon",Cities = new List<City>(){new City() { Name="Libreville", IsCapital=true} } },
                    new Country() { Name="Gambia",Cities = new List<City>(){new City() { Name="Banjul", IsCapital=true} } },
                    new Country() { Name="Georgia",Cities = new List<City>(){new City() { Name="Tbilisi", IsCapital=true} } },
                    new Country() { Name="Germany",Cities = new List<City>(){new City() { Name="Berlin", IsCapital=true} } },
                    new Country() { Name="Ghana",Cities = new List<City>(){new City() { Name="Accra", IsCapital=true} } },
                    new Country() { Name="Greece",Cities = new List<City>(){new City() { Name="Athens", IsCapital=true} } },
                    new Country() { Name="Grenada",Cities = new List<City>(){new City() { Name="Saint George's", IsCapital=true} } },
                    new Country() { Name="Guam",Cities = new List<City>(){new City() { Name="Hagta", IsCapital=true} } },
                    new Country() { Name="Guatemala",Cities = new List<City>(){new City() { Name="Guatemala City", IsCapital=true} } },
                    new Country() { Name="Guinea",Cities = new List<City>(){new City() { Name="Conakry", IsCapital=true} } },
                    new Country() { Name="Guinea-Bissau",Cities = new List<City>(){new City() { Name="Bissau", IsCapital=true} } },
                    new Country() { Name="Guyana",Cities = new List<City>(){new City() { Name="Georgetown", IsCapital=true} } },
                    new Country() { Name="Haiti",Cities = new List<City>(){new City() { Name="Port-au-Prince", IsCapital=true} } },
                    new Country() { Name="Honduras",Cities = new List<City>(){new City() { Name="Tegucigalpa", IsCapital=true} } },
                    new Country() { Name="Hungary",Cities = new List<City>(){new City() { Name="Budapest", IsCapital=true} } },
                    new Country() { Name="Iceland",Cities = new List<City>(){new City() { Name="Reykjavik", IsCapital=true} } },
                    new Country() { Name="India",Cities = new List<City>(){new City() { Name="New Delhi", IsCapital=true} } },
                    new Country() { Name="Indonesia",Cities = new List<City>(){new City() { Name="Jakarta", IsCapital=true} } },
                    new Country() { Name="Iran",Cities = new List<City>(){new City() { Name="Tehran", IsCapital=true} } },
                    new Country() { Name="Iraq",Cities = new List<City>(){new City() { Name="Baghdad", IsCapital=true} } },
                    new Country() { Name="Ireland",Cities = new List<City>(){new City() { Name="Dublin", IsCapital=true} } },
                    new Country() { Name="Israel",Cities = new List<City>(){new City() { Name="Jerusalem", IsCapital=true} } },
                    new Country() { Name="Italy",Cities = new List<City>(){new City() { Name="Rome", IsCapital=true} } },
                    new Country() { Name="Jamaica",Cities = new List<City>(){new City() { Name="Kingston", IsCapital=true} } },
                    new Country() { Name="Japan",Cities = new List<City>(){new City() { Name="Tokyo", IsCapital=true} } },
                    new Country() { Name="Jordan",Cities = new List<City>(){new City() { Name="Amman", IsCapital=true} } },
                    new Country() { Name="Kazakhstan",Cities = new List<City>(){new City() { Name="Nur-Sultan", IsCapital=true} } },
                    new Country() { Name="Kenya",Cities = new List<City>(){new City() { Name="Nairobi", IsCapital=true} } },
                    new Country() { Name="Kiribati",Cities = new List<City>(){new City() { Name="Tarawa", IsCapital=true} } },
                    new Country() { Name="Kuwait",Cities = new List<City>(){new City() { Name="Kuwait City", IsCapital=true} } },
                    new Country() { Name="Kyrgyzstan",Cities = new List<City>(){new City() { Name="Bishkek", IsCapital=true} } },
                    new Country() { Name="Laos",Cities = new List<City>(){new City() { Name="Vientiane", IsCapital=true} } },
                    new Country() { Name="Latvia",Cities = new List<City>(){new City() { Name="Riga", IsCapital=true} } },
                    new Country() { Name="Lebanon",Cities = new List<City>(){new City() { Name="Beirut", IsCapital=true} } },
                    new Country() { Name="Lesotho",Cities = new List<City>(){new City() { Name="Maseru", IsCapital=true} } },
                    new Country() { Name="Liberia",Cities = new List<City>(){new City() { Name="Monrovia", IsCapital=true} } },
                    new Country() { Name="Libya",Cities = new List<City>(){new City() { Name="Tripoli", IsCapital=true} } },
                    new Country() { Name="Liechtenstein",Cities = new List<City>(){new City() { Name="Vaduz", IsCapital=true} } },
                    new Country() { Name="Lithuania",Cities = new List<City>(){new City() { Name="Vilnius", IsCapital=true} } },
                    new Country() { Name="Luxembourg",Cities = new List<City>(){new City() { Name="Luxembourg", IsCapital=true} } },
                    new Country() { Name="Madagascar",Cities = new List<City>(){new City() { Name="Antananarivo", IsCapital=true} } },
                    new Country() { Name="Malawi",Cities = new List<City>(){new City() { Name="Lilongwe", IsCapital=true} } },
                    new Country() { Name="Malaysia",Cities = new List<City>(){new City() { Name="Kuala Lumpur", IsCapital=true} } },
                    new Country() { Name="Maldives",Cities = new List<City>(){new City() { Name="Male", IsCapital=true} } },
                    new Country() { Name="Mali",Cities = new List<City>(){new City() { Name="Bamako", IsCapital=true} } },
                    new Country() { Name="Malta",Cities = new List<City>(){new City() { Name="Valletta", IsCapital=true} } },
                    new Country() { Name="Marshall Islands",Cities = new List<City>(){new City() { Name="Majuro", IsCapital=true} } },
                    new Country() { Name="Mauritania",Cities = new List<City>(){new City() { Name="Nouakchott", IsCapital=true} } },
                    new Country() { Name="Mauritius",Cities = new List<City>(){new City() { Name="Port Louis", IsCapital=true} } },
                    new Country() { Name="Mexico",Cities = new List<City>(){new City() { Name="Mexico City", IsCapital=true} } },
                    new Country() { Name="Micronesia",Cities = new List<City>(){new City() { Name="Palikir", IsCapital=true} } },
                    new Country() { Name="Moldova",Cities = new List<City>(){new City() { Name="Chisinau", IsCapital=true} } },
                    new Country() { Name="Monaco",Cities = new List<City>(){new City() { Name="Monaco", IsCapital=true} } },
                    new Country() { Name="Mongolia",Cities = new List<City>(){new City() { Name="Ulaanbaatar", IsCapital=true} } },
                    new Country() { Name="Montenegro",Cities = new List<City>(){new City() { Name="Podgorica", IsCapital=true} } },
                    new Country() { Name="Morocco",Cities = new List<City>(){new City() { Name="Rabat", IsCapital=true} } },
                    new Country() { Name="Mozambique",Cities = new List<City>(){new City() { Name="Maputo", IsCapital=true} } },
                    new Country() { Name="Myanmar",Cities = new List<City>(){new City() { Name="Nay Pyi Taw", IsCapital=true} } },
                    new Country() { Name="Myanmar",Cities = new List<City>(){new City() { Name="Rangoon", IsCapital=true} } },
                    new Country() { Name="Namibia",Cities = new List<City>(){new City() { Name="Windhoek", IsCapital=true} } },
                    new Country() { Name="Nepal",Cities = new List<City>(){new City() { Name="Kathmandu", IsCapital=true} } },
                    new Country() { Name="Netherlands",Cities = new List<City>(){new City() { Name="The Hague", IsCapital=true} } },
                    new Country() { Name="Netherlands",Cities = new List<City>(){new City() { Name="Amsterdam", IsCapital=true} } },
                    new Country() { Name="New Zealand",Cities = new List<City>(){new City() { Name="Wellington", IsCapital=true} } },
                    new Country() { Name="Nicaragua",Cities = new List<City>(){new City() { Name="Managua", IsCapital=true} } },
                    new Country() { Name="Niger",Cities = new List<City>(){new City() { Name="Niamey", IsCapital=true} } },
                    new Country() { Name="Nigeria",Cities = new List<City>(){new City() { Name="Abuja", IsCapital=true} } },
                    new Country() { Name="Niue",Cities = new List<City>(){new City() { Name="Alofi", IsCapital=true} } },
                    new Country() { Name="North Korea",Cities = new List<City>(){new City() { Name="Pyongyang", IsCapital=true} } },
                    new Country() { Name="North Macedonia",Cities = new List<City>(){new City() { Name="Skopje", IsCapital=true} } },
                    new Country() { Name="Northern Mariana Islands",Cities = new List<City>(){new City() { Name="Capitol Hill", IsCapital=true} } },
                    new Country() { Name="Norway",Cities = new List<City>(){new City() { Name="Oslo", IsCapital=true} } },
                    new Country() { Name="Oman",Cities = new List<City>(){new City() { Name="Muscat", IsCapital=true} } },
                    new Country() { Name="Pakistan",Cities = new List<City>(){new City() { Name="Islamabad", IsCapital=true} } },
                    new Country() { Name="Palau",Cities = new List<City>(){new City() { Name="Ngerulmud", IsCapital=true} } },
                    new Country() { Name="Panama",Cities = new List<City>(){new City() { Name="Panama City", IsCapital=true} } },
                    new Country() { Name="Papua New Guinea",Cities = new List<City>(){new City() { Name="Port Moresby", IsCapital=true} } },
                    new Country() { Name="Paraguay",Cities = new List<City>(){new City() { Name="Asuncion", IsCapital=true} } },
                    new Country() { Name="Peru",Cities = new List<City>(){new City() { Name="Lima", IsCapital=true} } },
                    new Country() { Name="Philippines",Cities = new List<City>(){new City() { Name="Manila", IsCapital=true} } },
                    new Country() { Name="Pitcairn Islands",Cities = new List<City>(){new City() { Name="Adamstown", IsCapital=true} } },
                    new Country() { Name="Poland",Cities = new List<City>(){new City() { Name="Warsaw", IsCapital=true} } },
                    new Country() { Name="Portugal",Cities = new List<City>(){new City() { Name="Lisbon", IsCapital=true} } },
                    new Country() { Name="Qatar",Cities = new List<City>(){new City() { Name="Doha", IsCapital=true} } },
                    new Country() { Name="Republic of the Congo",Cities = new List<City>(){new City() { Name="Brazzaville", IsCapital=true} } },
                    new Country() { Name="Romania",Cities = new List<City>(){new City() { Name="Bucharest", IsCapital=true} } },
                    new Country() { Name="Russian Federation",Cities = new List<City>(){new City() { Name="Moscow", IsCapital=true} } },
                    new Country() { Name="Rwanda",Cities = new List<City>(){new City() { Name="Kigali", IsCapital=true} } },
                    new Country() { Name="Saint Kitts and Nevis",Cities = new List<City>(){new City() { Name="Basseterre", IsCapital=true} } },
                    new Country() { Name="Saint Lucia",Cities = new List<City>(){new City() { Name="Castries", IsCapital=true} } },
                    new Country() { Name="Saint Vincent and the Grenadines",Cities = new List<City>(){new City() { Name="Kingstown", IsCapital=true} } },
                    new Country() { Name="Samoa",Cities = new List<City>(){new City() { Name="Apia", IsCapital=true} } },
                    new Country() { Name="San Marino",Cities = new List<City>(){new City() { Name="San Marino", IsCapital=true} } },
                    new Country() { Name="Sao Tome and Principe",Cities = new List<City>(){new City() { Name="Sao Tome", IsCapital=true} } },
                    new Country() { Name="Saudi Arabia",Cities = new List<City>(){new City() { Name="Riyadh", IsCapital=true} } },
                    new Country() { Name="Senegal",Cities = new List<City>(){new City() { Name="Dakar", IsCapital=true} } },
                    new Country() { Name="Serbia",Cities = new List<City>(){new City() { Name="Belgrade", IsCapital=true} } },
                    new Country() { Name="Seychelles",Cities = new List<City>(){new City() { Name="Victoria", IsCapital=true} } },
                    new Country() { Name="Sierra Leone",Cities = new List<City>(){new City() { Name="Freetown", IsCapital=true} } },
                    new Country() { Name="Singapore",Cities = new List<City>(){new City() { Name="Singapore", IsCapital=true} } },
                    new Country() { Name="Sint Maarten (Dutch part)",Cities = new List<City>(){new City() { Name="Philipsburg", IsCapital=true} } },
                    new Country() { Name="Slovakia",Cities = new List<City>(){new City() { Name="Bratislava", IsCapital=true} } },
                    new Country() { Name="Slovenia",Cities = new List<City>(){new City() { Name="Ljubljana", IsCapital=true} } },
                    new Country() { Name="Solomon Islands",Cities = new List<City>(){new City() { Name="Honiara", IsCapital=true} } },
                    new Country() { Name="Somalia",Cities = new List<City>(){new City() { Name="Mogadishu", IsCapital=true} } },
                    new Country() { Name="South Africa",Cities = new List<City>(){new City() { Name="Cape Town", IsCapital=true} } },
                    new Country() { Name="South Korea",Cities = new List<City>(){new City() { Name="Seoul", IsCapital=true} } },
                    new Country() { Name="South Sudan",Cities = new List<City>(){new City() { Name="Juba", IsCapital=true} } },
                    new Country() { Name="Spain",Cities = new List<City>(){new City() { Name="Madrid", IsCapital=true} } },
                    new Country() { Name="Sri Lanka",Cities = new List<City>(){new City() { Name="Colombo", IsCapital=true} } },
                    new Country() { Name="Sri Lanka",Cities = new List<City>(){new City() { Name="Sri Jayewardenepura Kotte", IsCapital=true} } },
                    new Country() { Name="Sudan",Cities = new List<City>(){new City() { Name="Khartoum", IsCapital=true} } },
                    new Country() { Name="Suriname",Cities = new List<City>(){new City() { Name="Paramaribo", IsCapital=true} } },
                    new Country() { Name="Sweden",Cities = new List<City>(){new City() { Name="Stockholm", IsCapital=true} } },
                    new Country() { Name="Switzerland",Cities = new List<City>(){new City() { Name="Bern", IsCapital=true} } },
                    new Country() { Name="Syrian Arab Republic",Cities = new List<City>(){new City() { Name="Damascus", IsCapital=true} } },
                    new Country() { Name="Taiwan",Cities = new List<City>(){new City() { Name=" Taipei", IsCapital=true} } },
                    new Country() { Name="Tajikistan",Cities = new List<City>(){new City() { Name="Dushanbe", IsCapital=true} } },
                    new Country() { Name="Tanzania",Cities = new List<City>(){new City() { Name="Dar es Salaam", IsCapital=true} } },
                    new Country() { Name="Thailand",Cities = new List<City>(){new City() { Name="Bangkok", IsCapital=true} } },
                    new Country() { Name="Timor-Leste",Cities = new List<City>(){new City() { Name="Dili", IsCapital=true} } },
                    new Country() { Name="Togo",Cities = new List<City>(){new City() { Name="Lome", IsCapital=true} } },
                    new Country() { Name="Tonga",Cities = new List<City>(){new City() { Name="Nuku`alofa", IsCapital=true} } },
                    new Country() { Name="Trinidad and Tobago",Cities = new List<City>(){new City() { Name="Port of Spain", IsCapital=true} } },
                    new Country() { Name="Tunisia",Cities = new List<City>(){new City() { Name="Tunis", IsCapital=true} } },
                    new Country() { Name="Turkey",Cities = new List<City>(){new City() { Name="Ankara", IsCapital=true} } },
                    new Country() { Name="Turkmenistan",Cities = new List<City>(){new City() { Name="Ashgabat", IsCapital=true} } },
                    new Country() { Name="Tuvalu",Cities = new List<City>(){new City() { Name="Funafuti", IsCapital=true} } },
                    new Country() { Name="Uganda",Cities = new List<City>(){new City() { Name="Kampala", IsCapital=true} } },
                    new Country() { Name="Ukraine",Cities = new List<City>(){new City() { Name="Kyiv", IsCapital=true} } },
                    new Country() { Name="United Arab Emirates",Cities = new List<City>(){new City() { Name="Abu Dhabi", IsCapital=true} } },
                    new Country() { Name="United Kingdom",Cities = new List<City>(){new City() { Name="London", IsCapital=true} } },
                    new Country() { Name="Uruguay",Cities = new List<City>(){new City() { Name="Montevideo", IsCapital=true} } },
                    new Country() { Name="Uzbekistan",Cities = new List<City>(){new City() { Name="Tashkent", IsCapital=true} } },
                    new Country() { Name="Vanuatu",Cities = new List<City>(){new City() { Name="Port-Vila", IsCapital=true} } },
                    new Country() { Name="Venezuela",Cities = new List<City>(){new City() { Name="Caracas", IsCapital=true} } },
                    new Country() { Name="Vietnam",Cities = new List<City>(){new City() { Name="Hanoi", IsCapital=true} } },
                    new Country() { Name="Yemen",Cities = new List<City>(){new City() { Name="Sanaa", IsCapital=true} } },
                    new Country() { Name="Zambia",Cities = new List<City>(){new City() { Name="Lusaka", IsCapital=true} } },
                    new Country() { Name="Zimbabwe",Cities = new List<City>(){new City() { Name="Harare", IsCapital=true} } },
                    new Country() { Name="Åland Islands",Cities = new List<City>(){new City() { Name="Mariehamn", IsCapital=true} } }
                };
            }
        }
    }
}
