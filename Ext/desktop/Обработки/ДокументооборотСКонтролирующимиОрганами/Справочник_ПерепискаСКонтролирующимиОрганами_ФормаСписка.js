﻿Ext.define('Обработки.ДокументооборотСКонтролирующимиОрганами.Справочник_ПерепискаСКонтролирующимиОрганами_ФормаСписка',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:765px;height:300px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Справочник Переписка с контролирующими органами',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'ИсходящиеДокументыПФР',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:749px;height:259px;',
			height: 259,width: 749,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Картинка',
					flex:1,
				},
				{
					text:'Статус',
					width:'109',
					dataIndex:'Статус',
					flex:1,
				},
				{
					text:'Дата',
					width:'119',
					dataIndex:'ДатаСообщения',
					flex:1,
				},
				{
					text:'Отправитель',
					width:'112',
					dataIndex:'Отправитель',
					flex:1,
				},
				{
					text:'Получатель',
					width:'112',
					dataIndex:'Получатель',
					flex:1,
				},
				{
					text:'Тема',
					width:'144',
					dataIndex:'Наименование',
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
						name:'Статус',
					},
					{
						name:'ДатаСообщения',
					},
					{
						name:'Отправитель',
					},
					{
						name:'Получатель',
					},
					{
						name:'Наименование',
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
						var грид = Ext.getCmp('ИсходящиеДокументыПФР');
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
			style: 'position:absolute;left:0px;top:0px;width:765px;height:25px;',
			dock: 'top',
			items:
			[
				{
					text:'Выбрать',
				},
				'-',
			]
		},
	]
});