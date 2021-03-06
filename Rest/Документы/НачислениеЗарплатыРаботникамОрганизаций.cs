﻿
using System;
using Rest;
using System.Globalization;
using System.Collections.Generic;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace V82.Документы
{
	//NachislenieZarplatyRabotnikamOrganizacijj
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций","")]
	public class НачислениеЗарплатыРаботникамОрганизацийЗапрос: V82.ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций,IReturn<НачислениеЗарплатыРаботникамОрганизацийЗапрос>
	{
	}
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/НайтиПоСсылке","{Ссылка}")]
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/ПоСсылке","{Ссылка}")]
	public class НачислениеЗарплатыРаботникамОрганизацийНайтиПоСсылке: V82.ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций,IReturn<НачислениеЗарплатыРаботникамОрганизацийНайтиПоСсылке>
	{
	}
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/НайтиПоНомеру","{Номер}")]
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/ПоНомеру","{Номер}")]
	public class НачислениеЗарплатыРаботникамОрганизацийНайтиПоНомеру: V82.ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций,IReturn<НачислениеЗарплатыРаботникамОрганизацийНайтиПоНомеру>
	{
	}
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/ВыбратьПоСсылке","{___Первые}")]
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/ВыбратьПоСсылке","{___Первые}/{___Мин}")]
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/ВыбратьПоСсылке","{___Первые}/{___Мин}/{___Макс}")]
	public class НачислениеЗарплатыРаботникамОрганизацийВыбратьПоСсылке: V82.ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций,IReturn<НачислениеЗарплатыРаботникамОрганизацийВыбратьПоСсылке>
	{
		public int ___Первые {get; set;}
		public Guid ___Мин {get; set;}
		public Guid ___Макс {get; set;}
	}
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/ВыбратьПоНомеру","{___Первые}")]
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/ВыбратьПоНомеру","{___Первые}/{___Мин}")]
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/ВыбратьПоНомеру","{___Первые}/{___Мин}/{___Макс}")]
	public class НачислениеЗарплатыРаботникамОрганизацийВыбратьПоНомеру: V82.ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций,IReturn<НачислениеЗарплатыРаботникамОрганизацийВыбратьПоНомеру>
	{
		public int ___Первые {get; set;}
		public string ___Мин {get; set;}
		public string ___Макс {get; set;}
	}
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/СтраницаПоСсылке","{___Размер}/{___Номер}")]
	public class НачислениеЗарплатыРаботникамОрганизацийСтраницаПоСсылке: V82.ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций,IReturn<НачислениеЗарплатыРаботникамОрганизацийСтраницаПоСсылке>
	{
		public int ___Размер {get; set;}
		public int ___Номер {get; set;}
	}
	[Маршрут("Документы/НачислениеЗарплатыРаботникамОрганизаций/СтраницаПоНомеру","{___Размер}/{___Номер}")]
	public class НачислениеЗарплатыРаботникамОрганизацийСтраницаПоНомеру: V82.ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций,IReturn<НачислениеЗарплатыРаботникамОрганизацийСтраницаПоНомеру>
	{
		public int ___Размер {get; set;}
		public int ___Номер {get; set;}
	}

	public class НачислениеЗарплатыРаботникамОрганизацийОтвет
	{
		public string Ответ {get;set;}
	}

	public partial class НачислениеЗарплатыРаботникамОрганизацийСервис : Service
	{
		
		public object Get(НачислениеЗарплатыРаботникамОрганизацийЗапрос Запрос)
		{
			return null;
		}
		
		public object Get(НачислениеЗарплатыРаботникамОрганизацийНайтиПоСсылке Запрос)
		{
			if (Запрос.Ссылка == null)
			{
				return null;
			}
			var Ссылка = V82.Документы.НачислениеЗарплатыРаботникамОрганизаций.НайтиПоСсылке(Запрос.Ссылка);
			if (Ссылка == null)
			{
				return new НачислениеЗарплатыРаботникамОрганизацийОтвет() { Ответ = "НачислениеЗарплатыРаботникамОрганизаций c ссылкой '" + Запрос.Ссылка + "' не найден." };
			}
			return Ссылка.ПолучитьОбъект();
		}
		
		public object Get(НачислениеЗарплатыРаботникамОрганизацийНайтиПоНомеру Запрос)
		{
			if(Запрос.Номер == null)
			{
				return null;
			}
			var СтрокаНомер = System.Uri.UnescapeDataString(Запрос.Номер);
			var Ссылка = V82.Документы.НачислениеЗарплатыРаботникамОрганизаций.НайтиПоНомеру(СтрокаНомер);
			if (Ссылка == null)
			{
				return new НачислениеЗарплатыРаботникамОрганизацийОтвет() {Ответ = "НачислениеЗарплатыРаботникамОрганизаций c номером '" + Запрос.Номер + "' не найдено."};
			}
			return Ссылка.ПолучитьОбъект();
		}
		
		public object Get(НачислениеЗарплатыРаботникамОрганизацийВыбратьПоСсылке Запрос)
		{
			if (Запрос.___Макс == Guid.Empty)
			{
				Запрос.___Макс = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");
			}
			var Коллекция = new List<object>();
			foreach (var Ссылка in V82.Документы.НачислениеЗарплатыРаботникамОрганизаций.ВыбратьПоСсылке(Запрос.___Первые, Запрос.___Мин, Запрос.___Макс))
			{
				Коллекция.Add(Ссылка.ПолучитьОбъект());
			}
			return Коллекция;
		}
		
		public object Get(НачислениеЗарплатыРаботникамОрганизацийВыбратьПоНомеру Запрос)
		{
			return null;
		}
		
		public object Get(НачислениеЗарплатыРаботникамОрганизацийСтраницаПоСсылке Запрос)
		{
			return null;
		}
		
		public object Get(НачислениеЗарплатыРаботникамОрганизацийСтраницаПоНомеру Запрос)
		{
			return null;
		}

		public object Any(НачислениеЗарплатыРаботникамОрганизацийЗапрос Запрос)
		{
			return new НачислениеЗарплатыРаботникамОрганизацийОтвет {Ответ = "НачислениеЗарплатыРаботникамОрганизаций, "};
		}

		public object Post(НачислениеЗарплатыРаботникамОрганизацийЗапрос ЗапросНачислениеЗарплатыРаботникамОрганизаций)
		{
			var Ссылка = (ДокументыСсылка.НачислениеЗарплатыРаботникамОрганизаций)ЗапросНачислениеЗарплатыРаботникамОрганизаций;
			var Объект = Ссылка.ПолучитьОбъект();
			Объект.Записать();
			return null;
		}


	}
}