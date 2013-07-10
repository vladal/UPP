﻿Ext.define('Обработки.ДокументооборотСКонтролирующимиОрганами.РегистрСведений_НастройкиПользователейУчетныхЗаписейДокументооборота_ФормаСписка',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:689px;height:359px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Пользователи учетных записей документооборота и их настройки',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'РегистрСведенийСписок',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:673px;height:318px;',
			height: 318,width: 673,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Картинка',
					flex:1,
				},
				{
					text:'Учетная запись',
					width:'224',
					dataIndex:'УчетнаяЗапись',
					flex:1,
				},
				{
					text:'Пользователь',
					width:'224',
					dataIndex:'Пользователь',
					flex:1,
				},
				{
					text:'Интервал автообмена (мин.)',
					width:'172',
					dataIndex:'ИнтервалАвтообмена',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ДокументооборотСКонтролирующимиОрганами/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Картинка',
					},
					{
						name:'УчетнаяЗапись',
					},
					{
						name:'Пользователь',
					},
					{
						name:'ИнтервалАвтообмена',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('РегистрСведенийСписок');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:689px;height:25px;',
			dock: 'top',
			items:
			[
			]
		},
	]
});