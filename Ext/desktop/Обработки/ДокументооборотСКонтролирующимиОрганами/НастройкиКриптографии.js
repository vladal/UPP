﻿Ext.define('Обработки.ДокументооборотСКонтролирующимиОрганами.НастройкиКриптографии',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:606px;height:219px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Настройки криптографии',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'label',
			name: 'НадписьКриптопровайдер',
			text: 'Криптопровайдер:',
			style: 'position:absolute;left:8px;top:47px;width:108px;height:15px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Криптопровайдер',
			width: 478,
			height: 19,
			style: 'position:absolute;left:120px;top:45px;width:478px;height:19px;',
		},
		{
			xtype: 'fieldset',
			title: 'Алгоритмы',
			style: 'position:absolute;left:8px;top:68px;width:590px;height:16px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'АлгоритмПодписание',
			width: 478,
			height: 19,
			style: 'position:absolute;left:120px;top:89px;width:478px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьПодписание',
			text: 'Подписания:',
			style: 'position:absolute;left:8px;top:91px;width:108px;height:16px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'АлгоритмШифрование',
			width: 478,
			height: 19,
			style: 'position:absolute;left:120px;top:167px;width:478px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьШифрованиеДанных',
			text: 'Шифрования:',
			style: 'position:absolute;left:8px;top:117px;width:108px;height:16px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'АлгоритмХеширование',
			width: 478,
			height: 19,
			style: 'position:absolute;left:120px;top:141px;width:478px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьВысчислениеХешФункции',
			text: 'Хэширования:',
			style: 'position:absolute;left:8px;top:143px;width:108px;height:16px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'АлгоритмКлючи',
			width: 478,
			height: 19,
			style: 'position:absolute;left:120px;top:115px;width:478px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьОбменКлючами',
			text: 'Сессионные ключи:',
			style: 'position:absolute;left:8px;top:169px;width:108px;height:16px;',
		},
		{
			xtype: 'fieldset',
			title: '',
			style: 'position:absolute;left:8px;top:39px;width:590px;height:4px;',
		},
		{
			xtype: 'label',
			name: 'НадписьВнимание',
			text: 'Внимание!\r\nНастройки криптографии действительны для всех учетных записей, зарегистрированных в информационной базе!',
			style: 'position:absolute;left:8px;top:9px;width:590px;height:28px;text-align:left;',
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:194px;width:606px;height:25px;',
			dock: 'bottom',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'ОК',
				},
				'-',
				{
					text:'Отмена',
				},
				'-',
				{
					text:'Справка',
				},
			]
		},
	]
});