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
	public class ДоверенностиНалогоплательщика:V82.Rest.СправочникиТест.СправочникТест
	{
		public static ДоверенностиНалогоплательщикаЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ДоверенностиНалогоплательщика/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ДоверенностиНалогоплательщикаЗапрос ДоверенностиНалогоплательщикаЗапрос = null;
			try
			{
				ДоверенностиНалогоплательщикаЗапрос = Клиент.Get(new ДоверенностиНалогоплательщикаЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ДоверенностиНалогоплательщикаЗапрос;
		}
		public static ДоверенностиНалогоплательщикаЗапрос НайтиПоКоду(string Код)
		{
			var Урл = "http://localhost:1337/Справочники/ДоверенностиНалогоплательщика/НайтиПоКоду/"+Код+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ДоверенностиНалогоплательщикаЗапрос ДоверенностиНалогоплательщикаЗапрос = null;
			try
			{
				ДоверенностиНалогоплательщикаЗапрос = Клиент.Get(new ДоверенностиНалогоплательщикаЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ДоверенностиНалогоплательщикаЗапрос;
		}
		public static ДоверенностиНалогоплательщикаЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ДоверенностиНалогоплательщика/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ДоверенностиНалогоплательщикаЗапрос ДоверенностиНалогоплательщикаЗапрос = null;
			try
			{
				ДоверенностиНалогоплательщикаЗапрос = Клиент.Get(new ДоверенностиНалогоплательщикаЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ДоверенностиНалогоплательщикаЗапрос;
		}
		public static void ЗаписатьНовый(ДоверенностиНалогоплательщикаЗапрос ДоверенностиНалогоплательщикаЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/ДоверенностиНалогоплательщика?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ДоверенностиНалогоплательщикаОтвет = Клиент.Post(ДоверенностиНалогоплательщикаЗапрос);
		}
		public static void Записать(ДоверенностиНалогоплательщикаЗапрос ДоверенностиНалогоплательщикаЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/ДоверенностиНалогоплательщика?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ДоверенностиНалогоплательщикаОтвет = Клиент.Put(ДоверенностиНалогоплательщикаЗапрос);
		}
		public static void Удалить(ДоверенностиНалогоплательщикаЗапрос ДоверенностиНалогоплательщикаЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/ДоверенностиНалогоплательщика?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ДоверенностиНалогоплательщикаОтвет = Клиент.Delete(ДоверенностиНалогоплательщикаЗапрос);
		}
	}
}