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
	public class ИндивидуальныеГрафикиАмортизации:V82.Rest.СправочникиТест.СправочникТест
	{
		public static ИндивидуальныеГрафикиАмортизацииЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ИндивидуальныеГрафикиАмортизации/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ИндивидуальныеГрафикиАмортизацииЗапрос ИндивидуальныеГрафикиАмортизацииЗапрос = null;
			try
			{
				ИндивидуальныеГрафикиАмортизацииЗапрос = Клиент.Get(new ИндивидуальныеГрафикиАмортизацииЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ИндивидуальныеГрафикиАмортизацииЗапрос;
		}
		public static ИндивидуальныеГрафикиАмортизацииЗапрос НайтиПоКоду(string Код)
		{
			var Урл = "http://localhost:1337/Справочники/ИндивидуальныеГрафикиАмортизации/НайтиПоКоду/"+Код+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ИндивидуальныеГрафикиАмортизацииЗапрос ИндивидуальныеГрафикиАмортизацииЗапрос = null;
			try
			{
				ИндивидуальныеГрафикиАмортизацииЗапрос = Клиент.Get(new ИндивидуальныеГрафикиАмортизацииЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ИндивидуальныеГрафикиАмортизацииЗапрос;
		}
		public static ИндивидуальныеГрафикиАмортизацииЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ИндивидуальныеГрафикиАмортизации/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ИндивидуальныеГрафикиАмортизацииЗапрос ИндивидуальныеГрафикиАмортизацииЗапрос = null;
			try
			{
				ИндивидуальныеГрафикиАмортизацииЗапрос = Клиент.Get(new ИндивидуальныеГрафикиАмортизацииЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ИндивидуальныеГрафикиАмортизацииЗапрос;
		}
		public static void ЗаписатьНовый(ИндивидуальныеГрафикиАмортизацииЗапрос ИндивидуальныеГрафикиАмортизацииЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/ИндивидуальныеГрафикиАмортизации?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ИндивидуальныеГрафикиАмортизацииОтвет = Клиент.Post(ИндивидуальныеГрафикиАмортизацииЗапрос);
		}
		public static void Записать(ИндивидуальныеГрафикиАмортизацииЗапрос ИндивидуальныеГрафикиАмортизацииЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/ИндивидуальныеГрафикиАмортизации?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ИндивидуальныеГрафикиАмортизацииОтвет = Клиент.Put(ИндивидуальныеГрафикиАмортизацииЗапрос);
		}
		public static void Удалить(ИндивидуальныеГрафикиАмортизацииЗапрос ИндивидуальныеГрафикиАмортизацииЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/ИндивидуальныеГрафикиАмортизации?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ИндивидуальныеГрафикиАмортизацииОтвет = Клиент.Delete(ИндивидуальныеГрафикиАмортизацииЗапрос);
		}
	}
}