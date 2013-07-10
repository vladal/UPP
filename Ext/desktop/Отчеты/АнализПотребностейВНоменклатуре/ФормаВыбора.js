﻿Ext.define('Отчеты.АнализПотребностейВНоменклатуре.ФормаВыбора',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:252px;height:261px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Выбор поля',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'ДеревоВыбора',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:8px;width:236px;height:220px;',
			height: 220,width: 236,
			columns:
			[
				{
					text:'Представление',
					width:'220',
					dataIndex:'Представление',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/АнализПотребностейВНоменклатуре/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Представление',
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
						var грид = Ext.getCmp('ДеревоВыбора');
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
		{
			xtype: 'button',
			name: 'Отмена',
			text: 'Отмена',
			style: 'position:absolute;left:173px;top:233px;width:71px;height:20px;',
		},
		{
			xtype: 'button',
			name: 'ОК',
			text: 'ОК',
			style: 'position:absolute;left:96px;top:233px;width:71px;height:20px;',
		},
		],
	}],
	dockedItems:
	[
	]
});