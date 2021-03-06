﻿
using System;
using System.Runtime.Serialization;
using V82;
using V82.Перечисления;//Ссылка;
namespace V82.Перечисления//Ссылка
{
	[DataContract]
	public enum ОбработчикиДрайверовПодключаемогоОборудования
	{
		[NonSerialized]
		ПустаяСсылка = - 1,
	///<summary>
	///СканерШтрихкода
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"d706ac34-3097-4e1a-a090-d0ed690a910b\", \"Представление\":\"Обработчик1ССканерыШтрихкода\"}")]
		Обработчик1ССканерыШтрихкода = 0,//1С: Сканеры штрихкода
	///<summary>
	///СчитывательМагнитныхКарт
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"5d298dc5-efa9-45f0-9665-9b6b0252c76a\", \"Представление\":\"Обработчик1ССчитывателиМагнитныхКарт\"}")]
		Обработчик1ССчитывателиМагнитныхКарт = 1,//1С: Считыватели магнитных карт
	///<summary>
	///ФискальныйРегистратор
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"6f76c28f-3f40-4b5c-b505-624ef6ec5a4f\", \"Представление\":\"Обработчик1СФискальныйРегистраторЭмулятор\"}")]
		Обработчик1СФискальныйРегистраторЭмулятор = 2,//1С: Фискальный регистратор (эмулятор)
	///<summary>
	///ДисплейПокупателя
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"02235eb2-fc28-4809-b715-ab91063772da\", \"Представление\":\"ОбработчикАтолДисплеиПокупателя\"}")]
		ОбработчикАтолДисплеиПокупателя = 3,//АТОЛ: Дисплеи покупателя
	///<summary>
	///ККМOffline
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"6d612c75-cdac-45f2-9810-3f94401534b5\", \"Представление\":\"ОбработчикАтолККМOffline\"}")]
		ОбработчикАтолККМOffline = 4,//АТОЛ: Рабочее место кассира
	///<summary>
	///СканерШтрихкода
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"d5af826b-3a92-4681-bb5e-dae5e1516375\", \"Представление\":\"ОбработчикАтолСканерыШтрихкода\"}")]
		ОбработчикАтолСканерыШтрихкода = 5,//АТОЛ: Сканеры штрихкода
	///<summary>
	///СчитывательМагнитныхКарт
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"972ed56f-fa36-4d01-b73f-1f74abf5037b\", \"Представление\":\"ОбработчикАтолСчитывателиМагнитныхКарт\"}")]
		ОбработчикАтолСчитывателиМагнитныхКарт = 6,//АТОЛ: Считыватели магнитных карт
	///<summary>
	///ТерминалСбораДанных
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"cb572206-30fc-4702-a2f5-711397e11c1c\", \"Представление\":\"ОбработчикАтолТерминалыСбораДанных\"}")]
		ОбработчикАтолТерминалыСбораДанных = 7,//АТОЛ: Терминалы сбора данных
	///<summary>
	///ФискальныйРегистратор
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"c0f47771-4ca9-46c9-865e-ef39cd4e73a2\", \"Представление\":\"ОбработчикАтолФискальныеРегистраторы\"}")]
		ОбработчикАтолФискальныеРегистраторы = 8,//АТОЛ: Фискальные регистраторы
	///<summary>
	///ЭлектронныеВесы
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"a0edd2c5-0d9d-4669-a373-0ee6074df4e6\", \"Представление\":\"ОбработчикАтолЭлектронныеВесы\"}")]
		ОбработчикАтолЭлектронныеВесы = 9,//АТОЛ: Электронные весы
	///<summary>
	///ЭлектронныеВесы
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"cb829d05-c466-4f45-ab17-513f607876b7\", \"Представление\":\"ОбработчикШтрихМЭлектронныеВесы\"}")]
		ОбработчикШтрихМЭлектронныеВесы = 10,//Штрих-М: Электронные весы
	///<summary>
	///ФискальныйРегистратор
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"f0466427-6483-4a70-aa4c-e3fe34c3ffbe\", \"Представление\":\"ОбработчикВерсияТКасбиФР01К\"}")]
		ОбработчикВерсияТКасбиФР01К = 11,//Версия-Т: КАСБИ ФР-01К
	///<summary>
	///ЭквайринговыйТерминал
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"c41db6a2-742e-4451-adc4-e97532ea26a2\", \"Представление\":\"ОбработчикИНПАСЭквайринговыеТерминалы\"}")]
		ОбработчикИНПАСЭквайринговыеТерминалы = 12,//ИНПАС: Эквайринговые терминалы
	///<summary>
	///ЭквайринговыйТерминал
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"5c000000-78cf-4704-9ae6-28aa68d773b0\", \"Представление\":\"ОбработчикИНПАСЭквайринговыеТерминалыSmart\"}")]
		ОбработчикИНПАСЭквайринговыеТерминалыSmart = 13,//ИНПАС: Эквайринговые терминалы Smart
	///<summary>
	///ФискальныйРегистратор
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"fbedc08f-6d24-483b-8133-0ed6f6171ddb\", \"Представление\":\"ОбработчикККСФискальныеРегистраторыСпарк\"}")]
		ОбработчикККСФискальныеРегистраторыСпарк = 14,//ККС: Фискальные регистраторы "Спарк"
	///<summary>
	///ЭквайринговыйТерминал
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"98012e7d-d864-489e-867f-8c396a8fed21\", \"Представление\":\"ОбработчикСБРФЭквайринговыеТерминалы\"}")]
		ОбработчикСБРФЭквайринговыеТерминалы = 15,//СБ РФ: Эквайринговые терминалы
	///<summary>
	///ДисплейПокупателя
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"bfaee19a-4bcf-47d7-bbad-3946786ca669\", \"Представление\":\"ОбработчикСканкодДисплеиПокупателя\"}")]
		ОбработчикСканкодДисплеиПокупателя = 16,//SCANCODE: Дисплеи покупателя
	///<summary>
	///СканерШтрихкода
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"b9fcc8eb-fd2f-4780-b6a5-70bb6d30fac7\", \"Представление\":\"ОбработчикСканкодСканерыШтрихкода\"}")]
		ОбработчикСканкодСканерыШтрихкода = 17,//SCANCODE: Сканеры штрихкода
	///<summary>
	///ТерминалСбораДанных
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"d77e5534-5b70-465f-b15e-19e3d0c6782e\", \"Представление\":\"ОбработчикСканкодТерминалыСбораДанных\"}")]
		ОбработчикСканкодТерминалыСбораДанных = 18,//СКАНКОД: Терминалы сбора данных
	///<summary>
	///ФискальныйРегистратор
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"4218e013-5733-493c-bd2b-0d04064c3de0\", \"Представление\":\"ОбработчикШтрихМФискальныеРегистраторы\"}")]
		ОбработчикШтрихМФискальныеРегистраторы = 19,//Штрих-М: Фискальные регистраторы
	///<summary>
	///ЭквайринговыйТерминал
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"9b2092fb-ffef-4fe2-9039-776e4447c15a\", \"Представление\":\"ОбработчикСофткейсЭквайринговыеТерминалы\"}")]
		ОбработчикСофткейсЭквайринговыеТерминалы = 20,//СофтКейс: Эквайринговые терминалы
	///<summary>
	///ДисплейПокупателя
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"974336c6-63ae-4f03-aaf7-b52ce2c7f207\", \"Представление\":\"ОбработчикШтрихМДисплеиПокупателя\"}")]
		ОбработчикШтрихМДисплеиПокупателя = 21,//Штрих-М: Дисплеи покупателя
	///<summary>
	///ФискальныйРегистратор
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"d1a3f795-baf1-4a3b-952d-0891544af68b\", \"Представление\":\"ОбработчикОРИОНФискальныйРегистраторФР01К\"}")]
		ОбработчикОРИОНФискальныйРегистраторФР01К = 22,//ОРИОН: Фискальный регистратор ФР01К
	///<summary>
	///ККМOffline
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"535cfe1f-6a7b-4830-ad69-e7b4f0335575\", \"Представление\":\"ОбработчикШтрихМККМOffline\"}")]
		ОбработчикШтрихМККМOffline = 23,//Штрих-М: Кассир
	///<summary>
	///ТерминалСбораДанных
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"f52d8734-d18b-49b5-ba1b-952ec1dc4d34\", \"Представление\":\"ОбработчикШтрихМТерминалыСбораДанных\"}")]
		ОбработчикШтрихМТерминалыСбораДанных = 24,//Штрих-М: Терминалы сбора данных
	///<summary>
	///ВесыСПечатьюЭтикеток
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"d9721a2b-f955-4248-9d0e-e006d3b7433a\", \"Представление\":\"ОбработчикACOMВесыСПечатьюЭтикеток\"}")]
		ОбработчикACOMВесыСПечатьюЭтикеток = 25,//ACOM: Весы с печатью этикеток
	///<summary>
	///ВесыСПечатьюЭтикеток
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"088bf86b-31b9-4695-815c-7b7fc6507123\", \"Представление\":\"ОбработчикScaleCASВесыСПечатьюЭтикеток\"}")]
		ОбработчикScaleCASВесыСПечатьюЭтикеток = 26,//ScaleCAS: Весы c печатью этикеток CL5000J
	///<summary>
	///ВесыСПечатьюЭтикеток
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"e9412e04-b19c-4142-b6f9-1d6575e3c282\", \"Представление\":\"ОбработчикШтрихМВесыСПечатьюЭтикеток\"}")]
		ОбработчикШтрихМВесыСПечатьюЭтикеток = 27,//Штрих-М: Весы с печатью этикеток
	///<summary>
	///ТерминалСбораДанных
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"e2c7dbdf-6807-4974-aa9d-35331cd88f96\", \"Представление\":\"ОбработчикСканситиТерминалыСбораДанных\"}")]
		ОбработчикСканситиТерминалыСбораДанных = 28,//СКАНСИТИ: Терминалы сбора данных
	///<summary>
	///ДисплейПокупателя
	///</summary>
		[EnumMember(Value = "{\"Ссылка\":\"9dda0853-53b6-4531-adc5-a29653d373e0\", \"Представление\":\"ОбработчикККСДисплеиПокупателя\"}")]
		ОбработчикККСДисплеиПокупателя = 29,//ККС: Дисплеи покупателя
	}
	public static partial class ОбработчикиДрайверовПодключаемогоОборудования_Значения//:ПеречислениеСсылка
	{
		///<summary>
		///СканерШтрихкода
		///</summary>
		public static readonly Guid Обработчик1ССканерыШтрихкода = new Guid("edd090a0-0a69-0b91-4e1a-3097d706ac34");//1С: Сканеры штрихкода
		///<summary>
		///СчитывательМагнитныхКарт
		///</summary>
		public static readonly Guid Обработчик1ССчитывателиМагнитныхКарт = new Guid("6b9b6596-5202-6ac7-45f0-efa95d298dc5");//1С: Считыватели магнитных карт
		///<summary>
		///ФискальныйРегистратор
		///</summary>
		public static readonly Guid Обработчик1СФискальныйРегистраторЭмулятор = new Guid("4e6205b5-ecf6-4f5a-4b5c-3f406f76c28f");//1С: Фискальный регистратор (эмулятор)
		///<summary>
		///ДисплейПокупателя
		///</summary>
		public static readonly Guid ОбработчикАтолДисплеиПокупателя = new Guid("91ab15b7-3706-da72-4809-fc2802235eb2");//АТОЛ: Дисплеи покупателя
		///<summary>
		///ККМOffline
		///</summary>
		public static readonly Guid ОбработчикАтолККМOffline = new Guid("943f1098-1540-b534-45f2-cdac6d612c75");//АТОЛ: Рабочее место кассира
		///<summary>
		///СканерШтрихкода
		///</summary>
		public static readonly Guid ОбработчикАтолСканерыШтрихкода = new Guid("e5da5ebb-51e1-7563-4681-3a92d5af826b");//АТОЛ: Сканеры штрихкода
		///<summary>
		///СчитывательМагнитныхКарт
		///</summary>
		public static readonly Guid ОбработчикАтолСчитывателиМагнитныхКарт = new Guid("741f3fb7-f5ab-7b03-4d01-fa36972ed56f");//АТОЛ: Считыватели магнитных карт
		///<summary>
		///ТерминалСбораДанных
		///</summary>
		public static readonly Guid ОбработчикАтолТерминалыСбораДанных = new Guid("1371f5a2-e197-1c1c-4702-30fccb572206");//АТОЛ: Терминалы сбора данных
		///<summary>
		///ФискальныйРегистратор
		///</summary>
		public static readonly Guid ОбработчикАтолФискальныеРегистраторы = new Guid("39ef5e86-4ecd-a273-46c9-4ca9c0f47771");//АТОЛ: Фискальные регистраторы
		///<summary>
		///ЭлектронныеВесы
		///</summary>
		public static readonly Guid ОбработчикАтолЭлектронныеВесы = new Guid("e60e73a3-4d07-e6f4-4669-0d9da0edd2c5");//АТОЛ: Электронные весы
		///<summary>
		///ЭлектронныеВесы
		///</summary>
		public static readonly Guid ОбработчикШтрихМЭлектронныеВесы = new Guid("3f5117ab-7860-b776-4f45-c466cb829d05");//Штрих-М: Электронные весы
		///<summary>
		///ФискальныйРегистратор
		///</summary>
		public static readonly Guid ОбработчикВерсияТКасбиФР01К = new Guid("fee34caa-c334-beff-4a70-6483f0466427");//Версия-Т: КАСБИ ФР-01К
		///<summary>
		///ЭквайринговыйТерминал
		///</summary>
		public static readonly Guid ОбработчикИНПАСЭквайринговыеТерминалы = new Guid("75e9c4ad-ea32-a226-4451-742ec41db6a2");//ИНПАС: Эквайринговые терминалы
		///<summary>
		///ЭквайринговыйТерминал
		///</summary>
		public static readonly Guid ОбработчикИНПАСЭквайринговыеТерминалыSmart = new Guid("aa28e69a-d768-b073-4704-78cf5c000000");//ИНПАС: Эквайринговые терминалы Smart
		///<summary>
		///ФискальныйРегистратор
		///</summary>
		public static readonly Guid ОбработчикККСФискальныеРегистраторыСпарк = new Guid("d60e3381-17f6-db1d-483b-6d24fbedc08f");//ККС: Фискальные регистраторы "Спарк"
		///<summary>
		///ЭквайринговыйТерминал
		///</summary>
		public static readonly Guid ОбработчикСБРФЭквайринговыеТерминалы = new Guid("398c7f86-8f6a-21ed-489e-d86498012e7d");//СБ РФ: Эквайринговые терминалы
		///<summary>
		///ДисплейПокупателя
		///</summary>
		public static readonly Guid ОбработчикСканкодДисплеиПокупателя = new Guid("4639adbb-6c78-69a6-47d7-4bcfbfaee19a");//SCANCODE: Дисплеи покупателя
		///<summary>
		///СканерШтрихкода
		///</summary>
		public static readonly Guid ОбработчикСканкодСканерыШтрихкода = new Guid("bb70a5b6-306d-c7fa-4780-fd2fb9fcc8eb");//SCANCODE: Сканеры штрихкода
		///<summary>
		///ТерминалСбораДанных
		///</summary>
		public static readonly Guid ОбработчикСканкодТерминалыСбораДанных = new Guid("e3195eb1-c6d0-2e78-465f-5b70d77e5534");//СКАНКОД: Терминалы сбора данных
		///<summary>
		///ФискальныйРегистратор
		///</summary>
		public static readonly Guid ОбработчикШтрихМФискальныеРегистраторы = new Guid("040d2bbd-4c06-e03d-493c-57334218e013");//Штрих-М: Фискальные регистраторы
		///<summary>
		///ЭквайринговыйТерминал
		///</summary>
		public static readonly Guid ОбработчикСофткейсЭквайринговыеТерминалы = new Guid("6e773990-4744-5ac1-4fe2-ffef9b2092fb");//СофтКейс: Эквайринговые терминалы
		///<summary>
		///ДисплейПокупателя
		///</summary>
		public static readonly Guid ОбработчикШтрихМДисплеиПокупателя = new Guid("2cb5f7aa-c7e2-07f2-4f03-63ae974336c6");//Штрих-М: Дисплеи покупателя
		///<summary>
		///ФискальныйРегистратор
		///</summary>
		public static readonly Guid ОбработчикОРИОНФискальныйРегистраторФР01К = new Guid("91082d95-4a54-8bf6-4a3b-baf1d1a3f795");//ОРИОН: Фискальный регистратор ФР01К
		///<summary>
		///ККМOffline
		///</summary>
		public static readonly Guid ОбработчикШтрихМККМOffline = new Guid("b4e769ad-33f0-7555-4830-6a7b535cfe1f");//Штрих-М: Кассир
		///<summary>
		///ТерминалСбораДанных
		///</summary>
		public static readonly Guid ОбработчикШтрихМТерминалыСбораДанных = new Guid("2e951bba-dcc1-344d-49b5-d18bf52d8734");//Штрих-М: Терминалы сбора данных
		///<summary>
		///ВесыСПечатьюЭтикеток
		///</summary>
		public static readonly Guid ОбработчикACOMВесыСПечатьюЭтикеток = new Guid("06e00e9d-b7d3-3a43-4248-f955d9721a2b");//ACOM: Весы с печатью этикеток
		///<summary>
		///ВесыСПечатьюЭтикеток
		///</summary>
		public static readonly Guid ОбработчикScaleCASВесыСПечатьюЭтикеток = new Guid("7f7b5c81-50c6-2371-4695-31b9088bf86b");//ScaleCAS: Весы c печатью этикеток CL5000J
		///<summary>
		///ВесыСПечатьюЭтикеток
		///</summary>
		public static readonly Guid ОбработчикШтрихМВесыСПечатьюЭтикеток = new Guid("651df9b6-e375-82c2-4142-b19ce9412e04");//Штрих-М: Весы с печатью этикеток
		///<summary>
		///ТерминалСбораДанных
		///</summary>
		public static readonly Guid ОбработчикСканситиТерминалыСбораДанных = new Guid("33359daa-d81c-968f-4974-6807e2c7dbdf");//СКАНСИТИ: Терминалы сбора данных
		///<summary>
		///ДисплейПокупателя
		///</summary>
		public static readonly Guid ОбработчикККСДисплеиПокупателя = new Guid("96a2c5ad-d353-e073-4531-53b69dda0853");//ККС: Дисплеи покупателя
		public static ОбработчикиДрайверовПодключаемогоОборудования Получить(this ОбработчикиДрайверовПодключаемогоОборудования Значение, byte[] Ссылка)
		{
			return Получить(Значение, new Guid(Ссылка));
		}
		public static ОбработчикиДрайверовПодключаемогоОборудования Получить(this ОбработчикиДрайверовПодключаемогоОборудования Значение, Guid Ссылка)
		{
			if(Ссылка == Обработчик1ССканерыШтрихкода)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.Обработчик1ССканерыШтрихкода;
			}
			else if(Ссылка == Обработчик1ССчитывателиМагнитныхКарт)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.Обработчик1ССчитывателиМагнитныхКарт;
			}
			else if(Ссылка == Обработчик1СФискальныйРегистраторЭмулятор)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.Обработчик1СФискальныйРегистраторЭмулятор;
			}
			else if(Ссылка == ОбработчикАтолДисплеиПокупателя)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолДисплеиПокупателя;
			}
			else if(Ссылка == ОбработчикАтолККМOffline)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолККМOffline;
			}
			else if(Ссылка == ОбработчикАтолСканерыШтрихкода)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолСканерыШтрихкода;
			}
			else if(Ссылка == ОбработчикАтолСчитывателиМагнитныхКарт)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолСчитывателиМагнитныхКарт;
			}
			else if(Ссылка == ОбработчикАтолТерминалыСбораДанных)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолТерминалыСбораДанных;
			}
			else if(Ссылка == ОбработчикАтолФискальныеРегистраторы)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолФискальныеРегистраторы;
			}
			else if(Ссылка == ОбработчикАтолЭлектронныеВесы)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолЭлектронныеВесы;
			}
			else if(Ссылка == ОбработчикШтрихМЭлектронныеВесы)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМЭлектронныеВесы;
			}
			else if(Ссылка == ОбработчикВерсияТКасбиФР01К)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикВерсияТКасбиФР01К;
			}
			else if(Ссылка == ОбработчикИНПАСЭквайринговыеТерминалы)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикИНПАСЭквайринговыеТерминалы;
			}
			else if(Ссылка == ОбработчикИНПАСЭквайринговыеТерминалыSmart)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикИНПАСЭквайринговыеТерминалыSmart;
			}
			else if(Ссылка == ОбработчикККСФискальныеРегистраторыСпарк)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикККСФискальныеРегистраторыСпарк;
			}
			else if(Ссылка == ОбработчикСБРФЭквайринговыеТерминалы)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСБРФЭквайринговыеТерминалы;
			}
			else if(Ссылка == ОбработчикСканкодДисплеиПокупателя)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСканкодДисплеиПокупателя;
			}
			else if(Ссылка == ОбработчикСканкодСканерыШтрихкода)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСканкодСканерыШтрихкода;
			}
			else if(Ссылка == ОбработчикСканкодТерминалыСбораДанных)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСканкодТерминалыСбораДанных;
			}
			else if(Ссылка == ОбработчикШтрихМФискальныеРегистраторы)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМФискальныеРегистраторы;
			}
			else if(Ссылка == ОбработчикСофткейсЭквайринговыеТерминалы)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСофткейсЭквайринговыеТерминалы;
			}
			else if(Ссылка == ОбработчикШтрихМДисплеиПокупателя)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМДисплеиПокупателя;
			}
			else if(Ссылка == ОбработчикОРИОНФискальныйРегистраторФР01К)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикОРИОНФискальныйРегистраторФР01К;
			}
			else if(Ссылка == ОбработчикШтрихМККМOffline)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМККМOffline;
			}
			else if(Ссылка == ОбработчикШтрихМТерминалыСбораДанных)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМТерминалыСбораДанных;
			}
			else if(Ссылка == ОбработчикACOMВесыСПечатьюЭтикеток)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикACOMВесыСПечатьюЭтикеток;
			}
			else if(Ссылка == ОбработчикScaleCASВесыСПечатьюЭтикеток)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикScaleCASВесыСПечатьюЭтикеток;
			}
			else if(Ссылка == ОбработчикШтрихМВесыСПечатьюЭтикеток)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМВесыСПечатьюЭтикеток;
			}
			else if(Ссылка == ОбработчикСканситиТерминалыСбораДанных)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСканситиТерминалыСбораДанных;
			}
			else if(Ссылка == ОбработчикККСДисплеиПокупателя)
			{
				return ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикККСДисплеиПокупателя;
			}
			return ОбработчикиДрайверовПодключаемогоОборудования.ПустаяСсылка;
		}
		public static byte[] Ключ(this ОбработчикиДрайверовПодключаемогоОборудования Значение)
		{
			return Ссылка(Значение).ToByteArray();
		}
		public static Guid Ссылка(this ОбработчикиДрайверовПодключаемогоОборудования Значение)
		{
			switch (Значение)
			{
				case ОбработчикиДрайверовПодключаемогоОборудования.Обработчик1ССканерыШтрихкода: return Обработчик1ССканерыШтрихкода;
				case ОбработчикиДрайверовПодключаемогоОборудования.Обработчик1ССчитывателиМагнитныхКарт: return Обработчик1ССчитывателиМагнитныхКарт;
				case ОбработчикиДрайверовПодключаемогоОборудования.Обработчик1СФискальныйРегистраторЭмулятор: return Обработчик1СФискальныйРегистраторЭмулятор;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолДисплеиПокупателя: return ОбработчикАтолДисплеиПокупателя;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолККМOffline: return ОбработчикАтолККМOffline;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолСканерыШтрихкода: return ОбработчикАтолСканерыШтрихкода;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолСчитывателиМагнитныхКарт: return ОбработчикАтолСчитывателиМагнитныхКарт;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолТерминалыСбораДанных: return ОбработчикАтолТерминалыСбораДанных;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолФискальныеРегистраторы: return ОбработчикАтолФискальныеРегистраторы;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикАтолЭлектронныеВесы: return ОбработчикАтолЭлектронныеВесы;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМЭлектронныеВесы: return ОбработчикШтрихМЭлектронныеВесы;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикВерсияТКасбиФР01К: return ОбработчикВерсияТКасбиФР01К;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикИНПАСЭквайринговыеТерминалы: return ОбработчикИНПАСЭквайринговыеТерминалы;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикИНПАСЭквайринговыеТерминалыSmart: return ОбработчикИНПАСЭквайринговыеТерминалыSmart;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикККСФискальныеРегистраторыСпарк: return ОбработчикККСФискальныеРегистраторыСпарк;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСБРФЭквайринговыеТерминалы: return ОбработчикСБРФЭквайринговыеТерминалы;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСканкодДисплеиПокупателя: return ОбработчикСканкодДисплеиПокупателя;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСканкодСканерыШтрихкода: return ОбработчикСканкодСканерыШтрихкода;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСканкодТерминалыСбораДанных: return ОбработчикСканкодТерминалыСбораДанных;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМФискальныеРегистраторы: return ОбработчикШтрихМФискальныеРегистраторы;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСофткейсЭквайринговыеТерминалы: return ОбработчикСофткейсЭквайринговыеТерминалы;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМДисплеиПокупателя: return ОбработчикШтрихМДисплеиПокупателя;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикОРИОНФискальныйРегистраторФР01К: return ОбработчикОРИОНФискальныйРегистраторФР01К;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМККМOffline: return ОбработчикШтрихМККМOffline;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМТерминалыСбораДанных: return ОбработчикШтрихМТерминалыСбораДанных;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикACOMВесыСПечатьюЭтикеток: return ОбработчикACOMВесыСПечатьюЭтикеток;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикScaleCASВесыСПечатьюЭтикеток: return ОбработчикScaleCASВесыСПечатьюЭтикеток;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикШтрихМВесыСПечатьюЭтикеток: return ОбработчикШтрихМВесыСПечатьюЭтикеток;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикСканситиТерминалыСбораДанных: return ОбработчикСканситиТерминалыСбораДанных;
				case ОбработчикиДрайверовПодключаемогоОборудования.ОбработчикККСДисплеиПокупателя: return ОбработчикККСДисплеиПокупателя;
			}
			return Guid.Empty;
		}
	}
}