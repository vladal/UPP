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
	public class ДокументыРеализацииПолномочийНалоговыхОрганов:V82.Rest.СправочникиТест.СправочникТест
	{
		public static ДокументыРеализацииПолномочийНалоговыхОргановЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ДокументыРеализацииПолномочийНалоговыхОрганов/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ДокументыРеализацииПолномочийНалоговыхОргановЗапрос ДокументыРеализацииПолномочийНалоговыхОргановЗапрос = null;
			try
			{
				ДокументыРеализацииПолномочийНалоговыхОргановЗапрос = Клиент.Get(new ДокументыРеализацииПолномочийНалоговыхОргановЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ДокументыРеализацииПолномочийНалоговыхОргановЗапрос;
		}
		public static ДокументыРеализацииПолномочийНалоговыхОргановЗапрос НайтиПоКоду(string Код)
		{
			var Урл = "http://localhost:1337/Справочники/ДокументыРеализацииПолномочийНалоговыхОрганов/НайтиПоКоду/"+Код+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ДокументыРеализацииПолномочийНалоговыхОргановЗапрос ДокументыРеализацииПолномочийНалоговыхОргановЗапрос = null;
			try
			{
				ДокументыРеализацииПолномочийНалоговыхОргановЗапрос = Клиент.Get(new ДокументыРеализацииПолномочийНалоговыхОргановЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ДокументыРеализацииПолномочийНалоговыхОргановЗапрос;
		}
		public static ДокументыРеализацииПолномочийНалоговыхОргановЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ДокументыРеализацииПолномочийНалоговыхОрганов/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ДокументыРеализацииПолномочийНалоговыхОргановЗапрос ДокументыРеализацииПолномочийНалоговыхОргановЗапрос = null;
			try
			{
				ДокументыРеализацииПолномочийНалоговыхОргановЗапрос = Клиент.Get(new ДокументыРеализацииПолномочийНалоговыхОргановЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ДокументыРеализацииПолномочийНалоговыхОргановЗапрос;
		}
		public static void ЗаписатьНовый(ДокументыРеализацииПолномочийНалоговыхОргановЗапрос ДокументыРеализацииПолномочийНалоговыхОргановЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/ДокументыРеализацииПолномочийНалоговыхОрганов?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ДокументыРеализацииПолномочийНалоговыхОргановОтвет = Клиент.Post(ДокументыРеализацииПолномочийНалоговыхОргановЗапрос);
		}
		public static void Записать(ДокументыРеализацииПолномочийНалоговыхОргановЗапрос ДокументыРеализацииПолномочийНалоговыхОргановЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/ДокументыРеализацииПолномочийНалоговыхОрганов?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ДокументыРеализацииПолномочийНалоговыхОргановОтвет = Клиент.Put(ДокументыРеализацииПолномочийНалоговыхОргановЗапрос);
		}
		public static void Удалить(ДокументыРеализацииПолномочийНалоговыхОргановЗапрос ДокументыРеализацииПолномочийНалоговыхОргановЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/ДокументыРеализацииПолномочийНалоговыхОрганов?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ДокументыРеализацииПолномочийНалоговыхОргановОтвет = Клиент.Delete(ДокументыРеализацииПолномочийНалоговыхОргановЗапрос);
		}
	}
}