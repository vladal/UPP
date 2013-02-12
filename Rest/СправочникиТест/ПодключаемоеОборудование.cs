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
	public class ПодключаемоеОборудование:V82.Rest.СправочникиТест.СправочникТест
	{
		public static ПодключаемоеОборудованиеЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ПодключаемоеОборудование/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ПодключаемоеОборудованиеЗапрос ПодключаемоеОборудованиеЗапрос = null;
			try
			{
				ПодключаемоеОборудованиеЗапрос = Клиент.Get(new ПодключаемоеОборудованиеЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ПодключаемоеОборудованиеЗапрос;
		}
		public static ПодключаемоеОборудованиеЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ПодключаемоеОборудование/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ПодключаемоеОборудованиеЗапрос ПодключаемоеОборудованиеЗапрос = null;
			try
			{
				ПодключаемоеОборудованиеЗапрос = Клиент.Get(new ПодключаемоеОборудованиеЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ПодключаемоеОборудованиеЗапрос;
		}
		public static void ЗаписатьНовый(ПодключаемоеОборудованиеЗапрос ПодключаемоеОборудованиеЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/ПодключаемоеОборудование?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ПодключаемоеОборудованиеОтвет = Клиент.Post(ПодключаемоеОборудованиеЗапрос);
		}
		public static void Записать(ПодключаемоеОборудованиеЗапрос ПодключаемоеОборудованиеЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/ПодключаемоеОборудование?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ПодключаемоеОборудованиеОтвет = Клиент.Put(ПодключаемоеОборудованиеЗапрос);
		}
		public static void Удалить(ПодключаемоеОборудованиеЗапрос ПодключаемоеОборудованиеЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/ПодключаемоеОборудование?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ПодключаемоеОборудованиеОтвет = Клиент.Delete(ПодключаемоеОборудованиеЗапрос);
		}
	}
}