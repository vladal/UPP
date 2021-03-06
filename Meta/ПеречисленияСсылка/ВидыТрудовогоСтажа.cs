﻿
using System;
using System.Runtime.Serialization;
using V82;
using V82.Перечисления;//Ссылка;
namespace V82.Перечисления//Ссылка
{
	///<summary>
	///(Регл)
	///</summary>
	[DataContract]
	public enum ВидыТрудовогоСтажа
	{
		[NonSerialized]
		ПустаяСсылка = - 1,
		[EnumMember(Value = "{\"Ссылка\":\"8bba8041-e7d2-4af0-9ba6-16c7375dd710\", \"Представление\":\"ОбщийТрудовойСтаж\"}")]
		ОбщийТрудовойСтаж = 0,//Общий трудовой стаж
		[EnumMember(Value = "{\"Ссылка\":\"b99c820d-03a2-4347-b0cf-9bea64d7603b\", \"Представление\":\"ТерриториальныеУсловия\"}")]
		ТерриториальныеУсловия = 1,//Территориальные условия
		[EnumMember(Value = "{\"Ссылка\":\"fea835f7-48ea-42a5-be41-1f04b9dfc847\", \"Представление\":\"ОсобыеУсловияТруда\"}")]
		ОсобыеУсловияТруда = 2,//Особые условия труда
		[EnumMember(Value = "{\"Ссылка\":\"a562aa36-103e-4ef9-aec5-27ddea4a6110\", \"Представление\":\"ВыслугаЛет\"}")]
		ВыслугаЛет = 3,//Выслуга лет
	}
	public static partial class ВидыТрудовогоСтажа_Значения//:ПеречислениеСсылка
	{
		public static readonly Guid ОбщийТрудовойСтаж = new Guid("c716a69b-5d37-10d7-4af0-e7d28bba8041");//Общий трудовой стаж
		public static readonly Guid ТерриториальныеУсловия = new Guid("ea9bcfb0-d764-3b60-4347-03a2b99c820d");//Территориальные условия
		public static readonly Guid ОсобыеУсловияТруда = new Guid("041f41be-dfb9-47c8-42a5-48eafea835f7");//Особые условия труда
		public static readonly Guid ВыслугаЛет = new Guid("dd27c5ae-4aea-1061-4ef9-103ea562aa36");//Выслуга лет
		public static ВидыТрудовогоСтажа Получить(this ВидыТрудовогоСтажа Значение, byte[] Ссылка)
		{
			return Получить(Значение, new Guid(Ссылка));
		}
		public static ВидыТрудовогоСтажа Получить(this ВидыТрудовогоСтажа Значение, Guid Ссылка)
		{
			if(Ссылка == ОбщийТрудовойСтаж)
			{
				return ВидыТрудовогоСтажа.ОбщийТрудовойСтаж;
			}
			else if(Ссылка == ТерриториальныеУсловия)
			{
				return ВидыТрудовогоСтажа.ТерриториальныеУсловия;
			}
			else if(Ссылка == ОсобыеУсловияТруда)
			{
				return ВидыТрудовогоСтажа.ОсобыеУсловияТруда;
			}
			else if(Ссылка == ВыслугаЛет)
			{
				return ВидыТрудовогоСтажа.ВыслугаЛет;
			}
			return ВидыТрудовогоСтажа.ПустаяСсылка;
		}
		public static byte[] Ключ(this ВидыТрудовогоСтажа Значение)
		{
			return Ссылка(Значение).ToByteArray();
		}
		public static Guid Ссылка(this ВидыТрудовогоСтажа Значение)
		{
			switch (Значение)
			{
				case ВидыТрудовогоСтажа.ОбщийТрудовойСтаж: return ОбщийТрудовойСтаж;
				case ВидыТрудовогоСтажа.ТерриториальныеУсловия: return ТерриториальныеУсловия;
				case ВидыТрудовогоСтажа.ОсобыеУсловияТруда: return ОсобыеУсловияТруда;
				case ВидыТрудовогоСтажа.ВыслугаЛет: return ВыслугаЛет;
			}
			return Guid.Empty;
		}
	}
}