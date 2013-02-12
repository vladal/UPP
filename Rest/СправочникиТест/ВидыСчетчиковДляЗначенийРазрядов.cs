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
	public class ВидыСчетчиковДляЗначенийРазрядов:V82.Rest.СправочникиТест.СправочникТест
	{
		public static ВидыСчетчиковДляЗначенийРазрядовЗапрос НайтиПоУникальномуИдентификатору(Guid УникальныйИдентификатор)//ПолучитьПоСсылке,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ВидыСчетчиковДляЗначенийРазрядов/НайтиПоСсылке/"+УникальныйИдентификатор+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ВидыСчетчиковДляЗначенийРазрядовЗапрос ВидыСчетчиковДляЗначенийРазрядовЗапрос = null;
			try
			{
				ВидыСчетчиковДляЗначенийРазрядовЗапрос = Клиент.Get(new ВидыСчетчиковДляЗначенийРазрядовЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ВидыСчетчиковДляЗначенийРазрядовЗапрос;
		}
		public static ВидыСчетчиковДляЗначенийРазрядовЗапрос НайтиПоКоду(string Код)
		{
			var Урл = "http://localhost:1337/Справочники/ВидыСчетчиковДляЗначенийРазрядов/НайтиПоКоду/"+Код+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ВидыСчетчиковДляЗначенийРазрядовЗапрос ВидыСчетчиковДляЗначенийРазрядовЗапрос = null;
			try
			{
				ВидыСчетчиковДляЗначенийРазрядовЗапрос = Клиент.Get(new ВидыСчетчиковДляЗначенийРазрядовЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ВидыСчетчиковДляЗначенийРазрядовЗапрос;
		}
		public static ВидыСчетчиковДляЗначенийРазрядовЗапрос НайтиПоНаименованию(string Наименование)//ПолучитьПоНаименованию,Взять
		{
			var Урл = "http://localhost:1337/Справочники/ВидыСчетчиковДляЗначенийРазрядов/НайтиПоНаименованию/"+Наименование+"?format=json";
			var Клиент = new JsonServiceClient(Урл);
			ВидыСчетчиковДляЗначенийРазрядовЗапрос ВидыСчетчиковДляЗначенийРазрядовЗапрос = null;
			try
			{
				ВидыСчетчиковДляЗначенийРазрядовЗапрос = Клиент.Get(new ВидыСчетчиковДляЗначенийРазрядовЗапрос());
			}
			catch (Exception)
			{
				return null;
			}
			return ВидыСчетчиковДляЗначенийРазрядовЗапрос;
		}
		public static void ЗаписатьНовый(ВидыСчетчиковДляЗначенийРазрядовЗапрос ВидыСчетчиковДляЗначенийРазрядовЗапрос)//Положить
		{
			var Урл = "http://localhost:1337/Справочники/ВидыСчетчиковДляЗначенийРазрядов?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ВидыСчетчиковДляЗначенийРазрядовОтвет = Клиент.Post(ВидыСчетчиковДляЗначенийРазрядовЗапрос);
		}
		public static void Записать(ВидыСчетчиковДляЗначенийРазрядовЗапрос ВидыСчетчиковДляЗначенийРазрядовЗапрос)//Обновить
		{
			var Урл = "http://localhost:1337/Справочники/ВидыСчетчиковДляЗначенийРазрядов?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ВидыСчетчиковДляЗначенийРазрядовОтвет = Клиент.Put(ВидыСчетчиковДляЗначенийРазрядовЗапрос);
		}
		public static void Удалить(ВидыСчетчиковДляЗначенийРазрядовЗапрос ВидыСчетчиковДляЗначенийРазрядовЗапрос)//
		{
			var Урл = "http://localhost:1337/Справочники/ВидыСчетчиковДляЗначенийРазрядов?format=json";
			var Клиент = new JsonServiceClient(Урл);
			var ВидыСчетчиковДляЗначенийРазрядовОтвет = Клиент.Delete(ВидыСчетчиковДляЗначенийРазрядовЗапрос);
		}
	}
}