﻿
using System;
using System.Globalization;
using System.Collections.Generic;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceClient.Web;
using V82.Справочники;

namespace V82.Rest.СправочникиТест
{
	public class ВидыПараметровВыпускаПродукции:V82.Rest.СправочникиТест.СправочникТест
	{
		public static ВидыПараметровВыпускаПродукцииЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ВидыПараметровВыпускаПродукции/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ВидыПараметровВыпускаПродукцииЗапрос ВидыПараметровВыпускаПродукцииЗапрос = null;
			try
			{
				ВидыПараметровВыпускаПродукцииЗапрос = Клиент.Get(new ВидыПараметровВыпускаПродукцииЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ВидыПараметровВыпускаПродукцииЗапрос;
		}
		public static ВидыПараметровВыпускаПродукцииЗапрос НайтиПоКоду(string Код)
		{
			var Урл = "http://localhost:1337/Справочники/ВидыПараметровВыпускаПродукции/НайтиПоКоду/"+Код+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ВидыПараметровВыпускаПродукцииЗапрос ВидыПараметровВыпускаПродукцииЗапрос = null;
			try
			{
				ВидыПараметровВыпускаПродукцииЗапрос = Клиент.Get(new ВидыПараметровВыпускаПродукцииЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ВидыПараметровВыпускаПродукцииЗапрос;
		}
		public static ВидыПараметровВыпускаПродукцииЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ВидыПараметровВыпускаПродукции/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ВидыПараметровВыпускаПродукцииЗапрос ВидыПараметровВыпускаПродукцииЗапрос = null;
			try
			{
				ВидыПараметровВыпускаПродукцииЗапрос = Клиент.Get(new ВидыПараметровВыпускаПродукцииЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ВидыПараметровВыпускаПродукцииЗапрос;
		}
		public static void ЗаписатьНовый(ВидыПараметровВыпускаПродукцииЗапрос ВидыПараметровВыпускаПродукцииЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/ВидыПараметровВыпускаПродукции?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ВидыПараметровВыпускаПродукцииОтвет = Клиент.Post(ВидыПараметровВыпускаПродукцииЗапрос);
		}
		public static void Записать(ВидыПараметровВыпускаПродукцииЗапрос ВидыПараметровВыпускаПродукцииЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/ВидыПараметровВыпускаПродукции?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ВидыПараметровВыпускаПродукцииОтвет = Клиент.Put(ВидыПараметровВыпускаПродукцииЗапрос);
		}
		public static void Удалить(ВидыПараметровВыпускаПродукцииЗапрос ВидыПараметровВыпускаПродукцииЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/ВидыПараметровВыпускаПродукции?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ВидыПараметровВыпускаПродукцииОтвет = Клиент.Delete(ВидыПараметровВыпускаПродукцииЗапрос);
		}
	}
}