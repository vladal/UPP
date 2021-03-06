﻿
using System;
using Rest;
using System.Globalization;
using System.Collections.Generic;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace V82.Документы
{
	//GTDImport
	[Маршрут("Документы/ГТДИмпорт","")]
	public class ГТДИмпортЗапрос: V82.ДокументыСсылка.ГТДИмпорт,IReturn<ГТДИмпортЗапрос>
	{
	}
	[Маршрут("Документы/ГТДИмпорт/НайтиПоСсылке","{Ссылка}")]
	[Маршрут("Документы/ГТДИмпорт/ПоСсылке","{Ссылка}")]
	public class ГТДИмпортНайтиПоСсылке: V82.ДокументыСсылка.ГТДИмпорт,IReturn<ГТДИмпортНайтиПоСсылке>
	{
	}
	[Маршрут("Документы/ГТДИмпорт/НайтиПоНомеру","{Номер}")]
	[Маршрут("Документы/ГТДИмпорт/ПоНомеру","{Номер}")]
	public class ГТДИмпортНайтиПоНомеру: V82.ДокументыСсылка.ГТДИмпорт,IReturn<ГТДИмпортНайтиПоНомеру>
	{
	}
	[Маршрут("Документы/ГТДИмпорт/ВыбратьПоСсылке","{___Первые}")]
	[Маршрут("Документы/ГТДИмпорт/ВыбратьПоСсылке","{___Первые}/{___Мин}")]
	[Маршрут("Документы/ГТДИмпорт/ВыбратьПоСсылке","{___Первые}/{___Мин}/{___Макс}")]
	public class ГТДИмпортВыбратьПоСсылке: V82.ДокументыСсылка.ГТДИмпорт,IReturn<ГТДИмпортВыбратьПоСсылке>
	{
		public int ___Первые {get; set;}
		public Guid ___Мин {get; set;}
		public Guid ___Макс {get; set;}
	}
	[Маршрут("Документы/ГТДИмпорт/ВыбратьПоНомеру","{___Первые}")]
	[Маршрут("Документы/ГТДИмпорт/ВыбратьПоНомеру","{___Первые}/{___Мин}")]
	[Маршрут("Документы/ГТДИмпорт/ВыбратьПоНомеру","{___Первые}/{___Мин}/{___Макс}")]
	public class ГТДИмпортВыбратьПоНомеру: V82.ДокументыСсылка.ГТДИмпорт,IReturn<ГТДИмпортВыбратьПоНомеру>
	{
		public int ___Первые {get; set;}
		public string ___Мин {get; set;}
		public string ___Макс {get; set;}
	}
	[Маршрут("Документы/ГТДИмпорт/СтраницаПоСсылке","{___Размер}/{___Номер}")]
	public class ГТДИмпортСтраницаПоСсылке: V82.ДокументыСсылка.ГТДИмпорт,IReturn<ГТДИмпортСтраницаПоСсылке>
	{
		public int ___Размер {get; set;}
		public int ___Номер {get; set;}
	}
	[Маршрут("Документы/ГТДИмпорт/СтраницаПоНомеру","{___Размер}/{___Номер}")]
	public class ГТДИмпортСтраницаПоНомеру: V82.ДокументыСсылка.ГТДИмпорт,IReturn<ГТДИмпортСтраницаПоНомеру>
	{
		public int ___Размер {get; set;}
		public int ___Номер {get; set;}
	}

	public class ГТДИмпортОтвет
	{
		public string Ответ {get;set;}
	}

	public partial class ГТДИмпортСервис : Service
	{
		
		public object Get(ГТДИмпортЗапрос Запрос)
		{
			return null;
		}
		
		public object Get(ГТДИмпортНайтиПоСсылке Запрос)
		{
			if (Запрос.Ссылка == null)
			{
				return null;
			}
			var Ссылка = V82.Документы.ГТДИмпорт.НайтиПоСсылке(Запрос.Ссылка);
			if (Ссылка == null)
			{
				return new ГТДИмпортОтвет() { Ответ = "ГТДИмпорт c ссылкой '" + Запрос.Ссылка + "' не найден." };
			}
			return Ссылка.ПолучитьОбъект();
		}
		
		public object Get(ГТДИмпортНайтиПоНомеру Запрос)
		{
			if(Запрос.Номер == null)
			{
				return null;
			}
			var СтрокаНомер = System.Uri.UnescapeDataString(Запрос.Номер);
			var Ссылка = V82.Документы.ГТДИмпорт.НайтиПоНомеру(СтрокаНомер);
			if (Ссылка == null)
			{
				return new ГТДИмпортОтвет() {Ответ = "ГТДИмпорт c номером '" + Запрос.Номер + "' не найдено."};
			}
			return Ссылка.ПолучитьОбъект();
		}
		
		public object Get(ГТДИмпортВыбратьПоСсылке Запрос)
		{
			if (Запрос.___Макс == Guid.Empty)
			{
				Запрос.___Макс = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");
			}
			var Коллекция = new List<object>();
			foreach (var Ссылка in V82.Документы.ГТДИмпорт.ВыбратьПоСсылке(Запрос.___Первые, Запрос.___Мин, Запрос.___Макс))
			{
				Коллекция.Add(Ссылка.ПолучитьОбъект());
			}
			return Коллекция;
		}
		
		public object Get(ГТДИмпортВыбратьПоНомеру Запрос)
		{
			return null;
		}
		
		public object Get(ГТДИмпортСтраницаПоСсылке Запрос)
		{
			return null;
		}
		
		public object Get(ГТДИмпортСтраницаПоНомеру Запрос)
		{
			return null;
		}

		public object Any(ГТДИмпортЗапрос Запрос)
		{
			return new ГТДИмпортОтвет {Ответ = "ГТДИмпорт, "};
		}

		public object Post(ГТДИмпортЗапрос ЗапросГТДИмпорт)
		{
			var Ссылка = (ДокументыСсылка.ГТДИмпорт)ЗапросГТДИмпорт;
			var Объект = Ссылка.ПолучитьОбъект();
			Объект.Записать();
			return null;
		}


	}
}