<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscSignUp.ascx.cs" Debug="false" ClassName="AccessManagementService.Controls.SignUp" Inherits="AccessManagementService.Controls.UscSignUp" %>
<%@ Register TagPrefix="uc1" Assembly ="WebUtilityv2" Namespace="WebUtility.Controls"  %>
<style type="text/css">
    .captcha-image {
        float: left;
    }

    .textarea-controls .smart-form .checkbox {
        padding-left: 22px !important;
    }

    .smart-form *,
    .smart-form:after,
    .smart-form:before {
        margin: 0;
        padding: 0;
        box-sizing: content-box;
        -moz-box-sizing: content-box;
    }

    .smart-form .btn {
        box-sizing: border-box;
        -moz-box-sizing: border-box;
    }

    .smart-form .checkbox + .checkbox,
    .smart-form .radio + .radio {
        margin-top: 0;
    }

    .smart-form footer .btn {
        float: right;
        height: 31px;
        margin: 10px 0 0 5px;
        padding: 0 22px;
        font: 300 15px/29px 'Open Sans', Helvetica, Arial, sans-serif;
        cursor: pointer;
    }

    .smart-form legend {
        padding-top: 15px;
    }

    .smart-form {
        margin: 0;
        outline: 0;
        color: #666;
        position: relative;
    }

        .smart-form header {
            display: block;
            padding: 8px 0;
            border-bottom: 1px dashed rgba(0, 0, 0, .2);
            background: #fff;
            font-size: 16px;
            font-weight: 300;
            color: #232323;
            margin: 10px 14px 0;
        }

        .smart-form fieldset {
            display: block;
            padding: 25px 14px 5px;
            border: none;
            background: rgba(255, 255, 255, .9);
            position: relative;
        }

            .smart-form fieldset + fieldset {
                border-top: 1px solid rgba(0, 0, 0, .1);
            }

        .smart-form section {
            margin-bottom: 15px;
            position: relative;
        }

        .smart-form footer {
            display: block;
            padding: 7px 14px 15px;
            border-top: 1px solid rgba(0, 0, 0, .1);
            background: rgba(248, 248, 248, .9);
        }

            .smart-form footer:after {
                content: '';
                display: table;
                clear: both;
            }

        .smart-form .label {
            display: block;
            margin-bottom: 6px;
            line-height: 19px;
            font-weight: 400;
            font-size: 13px;
            color: #333;
            text-align: left;
            white-space: normal;
        }

            .smart-form .label.col {
                margin: 0;
                padding-top: 7px;
            }

        .note,
        .smart-form .note {
            margin-top: 6px;
            padding: 0 1px;
            font-size: 11px;
            line-height: 15px;
            color: #999;
        }

            .smart-form .note a {
                font-size: 13px;
            }

        .smart-form .button,
        .smart-form .checkbox,
        .smart-form .input,
        .smart-form .radio,
        .smart-form .select,
        .smart-form .textarea,
        .smart-form .toggle {
            position: relative;
            display: block;
            font-weight: 400;
        }

            .smart-form .input input,
            .smart-form .select select,
            .smart-form .textarea textarea {
                display: block;
                box-sizing: border-box;
                -moz-box-sizing: border-box;
                width: 100%;
                height: 32px;
                line-height: 32px;
                padding: 5px 10px;
                outline: 0;
                border-width: 1px;
                border-style: solid;
                border-radius: 0;
                background: #fff;
                font: 13px/16px 'Open Sans', Helvetica, Arial, sans-serif;
                color: #404040;
                appearance: normal;
                -moz-appearance: none;
                -webkit-appearance: none;
            }

        .smart-form .input-file .button {
            position: absolute;
            top: 4px;
            right: 4px;
            float: none;
            height: 22px;
            margin: 0;
            padding: 0 14px;
            font-size: 13px;
            line-height: 22px;
        }

            .smart-form .input-file .button:hover {
                box-shadow: none;
            }

            .smart-form .input-file .button input {
                position: absolute;
                top: 0;
                right: 0;
                padding: 0;
                font-size: 30px;
                cursor: pointer;
                opacity: 0;
            }

        .smart-form .select i {
            position: absolute;
            top: 10px;
            right: 11px;
            width: 5px;
            height: 11px;
            background: #fff;
            box-shadow: 0 0 0 9px #fff;
        }

            .smart-form .select i:after,
            .smart-form .select i:before {
                content: '';
                position: absolute;
                right: 0;
                border-right: 4px solid transparent;
                border-left: 4px solid transparent;
            }

            .smart-form .select i:after {
                bottom: 0;
                border-top: 4px solid #404040;
            }

            .smart-form .select i:before {
                top: 0;
                border-bottom: 4px solid #404040;
            }

        .smart-form .select-multiple select {
            height: auto;
        }

        .smart-form .textarea textarea {
            height: auto;
            resize: none;
        }

        .smart-form .textarea-resizable textarea {
            resize: vertical;
        }

        .smart-form .textarea-expandable textarea {
            height: 31px;
        }

            .smart-form .textarea-expandable textarea:focus {
                height: auto;
            }

        .smart-form .checkbox,
        .smart-form .radio {
            margin-bottom: 4px;
            padding-left: 25px;
            line-height: 25px;
            color: #404040;
            cursor: pointer;
            font-size: 13px;
        }

            .smart-form .checkbox:last-child,
            .smart-form .radio:last-child {
                margin-bottom: 0;
            }

            .smart-form .checkbox input,
            .smart-form .radio input {
                position: absolute;
                left: -9999px;
            }

            .smart-form .checkbox i,
            .smart-form .radio i {
                position: absolute;
                top: 3px;
                left: 0;
                display: block;
                width: 17px;
                height: 17px;
                outline: 0;
                border-width: 1px;
                border-style: solid;
                background: #FFF;
            }

            .smart-form .radio i {
                border-radius: 50%;
            }

            .smart-form .checkbox input + i:after,
            .smart-form .radio input + i:after {
                position: absolute;
                opacity: 0;
                transition: opacity .1s;
                -o-transition: opacity .1s;
                -ms-transition: opacity .1s;
                -moz-transition: opacity .1s;
                -webkit-transition: opacity .1s;
            }

            .smart-form .radio input + i:after {
                content: '';
                top: 4px;
                left: 4px;
                width: 9px;
                height: 9px;
                border-radius: 50%;
            }

            .smart-form .checkbox input + i:after {
                content: '\f00c';
                top: -1px;
                left: 1px;
                width: 15px;
                height: 15px;
                font: 400 16px/19px FontAwesome;
                text-align: center;
            }

            .smart-form .checkbox input:checked:hover + i:after {
                content: '\f00d';
            }

            .smart-form .checkbox input:checked:disabled:hover + i:after {
                content: '\f00c';
            }

            .smart-form .checkbox input:checked + i:after,
            .smart-form .radio input:checked + i:after {
                opacity: 1;
            }

        .smart-form .inline-group {
            margin: 0 -15px -4px 0;
        }

            .smart-form .inline-group:after {
                content: '';
                display: table;
                clear: both;
            }

            .smart-form .inline-group .checkbox,
            .smart-form .inline-group .radio {
                float: left;
                margin-right: 30px;
            }

                .smart-form .inline-group .checkbox:last-child,
                .smart-form .inline-group .radio:last-child {
                    margin-bottom: 4px;
                }

        .smart-form .toggle {
            margin-bottom: 4px;
            padding-right: 61px;
            font-size: 15px;
            line-height: 25px;
            color: #404040;
            cursor: pointer;
        }

            .smart-form .toggle:last-child {
                margin-bottom: 0;
            }

            .smart-form .toggle input {
                position: absolute;
                left: -9999px;
            }

            .smart-form .toggle i {
                content: '';
                position: absolute;
                top: 4px;
                right: 0;
                display: block;
                width: 49px;
                height: 17px;
                border-width: 1px;
                border-style: solid;
                border-radius: 12px;
                background: #fff;
            }

                .smart-form .toggle i:after {
                    content: attr(data-swchoff-text);
                    position: absolute;
                    top: 2px;
                    right: 8px;
                    left: 8px;
                    font-style: normal;
                    font-size: 9px;
                    line-height: 13px;
                    font-weight: 700;
                    text-align: left;
                    color: #5f5f5f;
                }

                .smart-form .toggle i:before {
                    content: '';
                    position: absolute;
                    z-index: 1;
                    top: 4px;
                    right: 4px;
                    display: block;
                    width: 9px;
                    height: 9px;
                    border-radius: 50%;
                    opacity: 1;
                    transition: right .2s;
                    -o-transition: right .2s;
                    -ms-transition: right .2s;
                    -moz-transition: right .2s;
                    -webkit-transition: right .2s;
                }

            .smart-form .toggle input:checked + i:after {
                content: attr(data-swchon-text);
                text-align: right;
            }

            .smart-form .toggle input:checked + i:before {
                right: 36px;
            }

        .smart-form .rating {
            margin-bottom: 4px;
            font-size: 13px;
            line-height: 25px;
            color: #404040;
        }

            .smart-form .rating:last-child {
                margin-bottom: 0;
            }

            .smart-form .rating input {
                position: absolute;
                left: -9999px;
            }

            .smart-form .rating label {
                display: block;
                float: right;
                height: 17px;
                margin-top: 5px;
                padding: 0 2px;
                font-size: 17px;
                line-height: 17px;
                cursor: pointer;
            }

        .smart-form .button {
            float: right;
            height: 31px;
            overflow: hidden;
            margin: 10px 0 0 5px;
            padding: 0 25px;
            outline: 0;
            border: 0;
            font: 300 15px/31px 'Open Sans', Helvetica, Arial, sans-serif;
            text-decoration: none;
            color: #fff;
            cursor: pointer;
        }

        .smart-form .icon-append,
        .smart-form .icon-prepend {
            position: absolute;
            top: 5px;
            width: 22px;
            height: 22px;
            font-size: 14px;
            line-height: 22px;
            text-align: center;
        }

        .smart-form .icon-append {
            right: 5px;
            padding-left: 3px;
            border-left-width: 1px;
            border-left-style: solid;
        }

        .smart-form .icon-prepend {
            left: 5px;
            padding-right: 3px;
            border-right-width: 1px;
            border-right-style: solid;
        }

        .smart-form .input .icon-prepend + input,
        .smart-form .textarea .icon-prepend + textarea {
            padding-left: 37px;
        }

        .smart-form .input .icon-append + input,
        .smart-form .textarea .icon-append + textarea {
            padding-right: 37px;
        }

        .smart-form .input .icon-prepend + .icon-append + input,
        .smart-form .textarea .icon-prepend + .icon-append + textarea {
            padding-left: 37px;
        }

        .smart-form .row {
            margin: 0 -15px;
        }

            .smart-form .row:after {
                content: '';
                display: table;
                clear: both;
            }

        .smart-form .col {
            float: left;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
            box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .smart-form .col-1 {
            width: 8.33%;
        }

        .smart-form .col-2 {
            width: 16.66%;
        }

        .smart-form .col-3 {
            width: 25%;
        }

        .smart-form .col-4 {
            width: 33.33%;
        }

        .smart-form .col-5 {
            width: 41.66%;
        }

        .smart-form .col-6 {
            width: 50%;
        }

        .smart-form .col-8 {
            width: 66.67%;
        }

        .smart-form .col-9 {
            width: 75%;
        }

        .smart-form .col-10 {
            width: 83.33%;
        }

    @media screen and (max-width:600px) {
        .smart-form .col {
            float: none;
            width: 100%;
        }
    }

    .smart-form .select select {
        padding: 5px;
    }

    .smart-form .tooltip {
        position: absolute;
        z-index: 99999;
        left: -9999px;
        padding: 2px 8px 3px;
        font-size: 11px;
        line-height: 16px;
        font-weight: 400;
        background: rgba(0, 0, 0, .9);
        color: #fff;
        opacity: 0;
        transition: margin .3s, opacity .3s;
        -o-transition: margin .3s, opacity .3s;
        -ms-transition: margin .3s, opacity .3s;
        -moz-transition: margin .3s, opacity .3s;
        -webkit-transition: margin .3s, opacity .3s;
    }

        .smart-form .tooltip:after {
            content: '';
            position: absolute;
        }

    .smart-form .input input:focus + .tooltip,
    .smart-form .textarea textarea:focus + .tooltip {
        opacity: 1;
    }

    .smart-form .tooltip-top-right {
        bottom: 100%;
        margin-bottom: 15px;
    }

        .smart-form .tooltip-top-right:after {
            top: 100%;
            right: 11px;
            border-top: 4px solid rgba(0, 0, 0, .9);
            border-right: 4px solid transparent;
            border-left: 4px solid transparent;
        }

    .smart-form .input input:focus + .tooltip-top-right,
    .smart-form .textarea textarea:focus + .tooltip-top-right {
        right: 0;
        left: auto;
        margin-bottom: 5px;
    }

    .smart-form .tooltip-top-left {
        bottom: 100%;
        margin-bottom: 15px;
    }

        .smart-form .tooltip-top-left:after {
            top: 100%;
            left: 11px;
            border-top: 4px solid rgba(0, 0, 0, .9);
            border-right: 4px solid transparent;
            border-left: 4px solid transparent;
        }

    .smart-form .input input:focus + .tooltip-top-left,
    .smart-form .textarea textarea:focus + .tooltip-top-left {
        right: auto;
        left: 0;
        margin-bottom: 5px;
    }

    .smart-form .tooltip-right {
        top: 4px;
        white-space: nowrap;
        margin-left: 15px;
    }

        .smart-form .tooltip-right:after {
            top: 6px;
            right: 100%;
            border-top: 4px solid transparent;
            border-right: 4px solid rgba(0, 0, 0, .9);
            border-bottom: 4px solid transparent;
        }

    .smart-form .input input:focus + .tooltip-right,
    .smart-form .textarea textarea:focus + .tooltip-right {
        left: 100%;
        margin-left: 5px;
    }

    .smart-form .tooltip-left {
        top: 4px;
        white-space: nowrap;
        margin-right: 15px;
    }

        .smart-form .tooltip-left:after {
            top: 6px;
            left: 100%;
            border-top: 4px solid transparent;
            border-bottom: 4px solid transparent;
            border-left: 4px solid rgba(0, 0, 0, .9);
        }

    .smart-form .input input:focus + .tooltip-left,
    .smart-form .textarea textarea:focus + .tooltip-left {
        right: 100%;
        left: auto;
        margin-right: 5px;
    }

    .smart-form .tooltip-bottom-right {
        top: 100%;
        margin-top: 15px;
    }

        .smart-form .tooltip-bottom-right:after {
            bottom: 100%;
            right: 11px;
            border-right: 4px solid transparent;
            border-bottom: 4px solid rgba(0, 0, 0, .9);
            border-left: 4px solid transparent;
        }

    .smart-form .input input:focus + .tooltip-bottom-right,
    .smart-form .textarea textarea:focus + .tooltip-bottom-right {
        right: 0;
        left: auto;
        margin-top: 5px;
    }

    .smart-form .tooltip-bottom-left {
        top: 100%;
        margin-top: 15px;
    }

        .smart-form .tooltip-bottom-left:after {
            bottom: 100%;
            left: 11px;
            border-right: 4px solid transparent;
            border-bottom: 4px solid rgba(0, 0, 0, .9);
            border-left: 4px solid transparent;
        }

    .smart-form .input input:focus + .tooltip-bottom-left,
    .smart-form .textarea textarea:focus + .tooltip-bottom-left {
        right: auto;
        left: 0;
        margin-top: 5px;
    }

    .smart-form .checkbox i,
    .smart-form .icon-append,
    .smart-form .icon-prepend,
    .smart-form .input input,
    .smart-form .radio i,
    .smart-form .select select,
    .smart-form .textarea textarea,
    .smart-form .toggle i {
        border-color: #BDBDBD;
        transition: border-color .3s;
        -o-transition: border-color .3s;
        -ms-transition: border-color .3s;
        -moz-transition: border-color .3s;
        -webkit-transition: border-color .3s;
    }

        .smart-form .toggle i:before {
            background-color: #3276B1;
        }

    .smart-form .rating label {
        color: #ccc;
        transition: color .3s;
        -o-transition: color .3s;
        -ms-transition: color .3s;
        -moz-transition: color .3s;
        -webkit-transition: color .3s;
    }

    .smart-form .button {
        background-color: #3276B1;
        opacity: .8;
        transition: opacity .2s;
        -o-transition: opacity .2s;
        -ms-transition: opacity .2s;
        -moz-transition: opacity .2s;
        -webkit-transition: opacity .2s;
    }

        .smart-form .button.button-secondary {
            background-color: #b3b3b3;
        }

    .smart-form .icon-append,
    .smart-form .icon-prepend {
        color: #A2A2A2;
    }

    .smart-form .checkbox:hover i,
    .smart-form .input:hover input,
    .smart-form .radio:hover i,
    .smart-form .select:hover select,
    .smart-form .textarea:hover textarea,
    .smart-form .toggle:hover i {
        border-color: #5D98CC;
    }

    .smart-form .rating input + label:hover,
    .smart-form .rating input + label:hover ~ label {
        color: #3276B1;
    }

    .smart-form .button:hover {
        opacity: 1;
    }

    .smart-form .checkbox:hover i,
    .smart-form .radio:hover i,
    .smart-form .toggle:hover i {
        -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .1);
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, .1);
    }

    .smart-form .checkbox:active i,
    .smart-form .radio:active i,
    .smart-form .toggle:active i {
        background: #F0F0F0;
        -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .1);
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, .1);
    }

    .smart-form .checkbox input:focus + i,
    .smart-form .input input:focus,
    .smart-form .radio input:focus + i,
    .smart-form .select select:focus,
    .smart-form .textarea textarea:focus,
    .smart-form .toggle input:focus + i {
        border-color: #3276B1;
    }

    .smart-form .radio input + i:after {
        background-color: #3276B1;
    }

    .smart-form .checkbox input + i:after {
        color: #3276B1;
    }

    .smart-form .checkbox input:checked + i,
    .smart-form .radio input:checked + i,
    .smart-form .toggle input:checked + i {
        border-color: #3276B1;
    }

    .smart-form .rating input:checked ~ label {
        color: #3276B1;
    }

    .smart-form .checkbox.state-error i,
    .smart-form .radio.state-error i,
    .smart-form .state-error input,
    .smart-form .state-error select,
    .smart-form .state-error textarea,
    .smart-form .toggle.state-error i {
        background: #fff0f0;
        border-color: #A90329;
    }

    .smart-form .toggle.state-error input:checked + i {
        background: #fff0f0;
    }

    .smart-form .state-error + em {
        display: block;
        margin-top: 6px;
        padding: 0 1px;
        font-style: normal;
        font-size: 11px;
        line-height: 15px;
        color: #D56161;
    }

    .smart-form .rating.state-error + em {
        margin-top: -4px;
        margin-bottom: 4px;
    }

    .smart-form .state-error select + i {
        background: #FFF0F0;
        box-shadow: 0 0 0 9px #FFF0F0;
    }

    .state-error .icon-append,
    .state-error .icon-prepend {
        color: #ed1c24;
    }

    .smart-form .checkbox.state-success i,
    .smart-form .radio.state-success i,
    .smart-form .state-success input,
    .smart-form .state-success select,
    .smart-form .state-success textarea,
    .smart-form .toggle.state-success i {
        background: #f0fff0;
        border-color: #7DC27D;
    }

    .smart-form .toggle.state-success input:checked + i {
        background: #f0fff0;
    }

    .smart-form .note-success {
        color: #6fb679;
    }

    .smart-form .state-success select + i {
        background: #f0fff0;
        box-shadow: 0 0 0 9px #f0fff0;
    }

    .smart-form .button.state-disabled,
    .smart-form .checkbox.state-disabled,
    .smart-form .input.state-disabled input,
    .smart-form .radio.state-disabled,
    .smart-form .select.state-disabled,
    .smart-form .textarea.state-disabled,
    .smart-form .toggle.state-disabled {
        cursor: default !important;
        opacity: .6 !important;
    }

        .smart-form .checkbox.state-disabled:hover i,
        .smart-form .input.state-disabled:hover input,
        .smart-form .radio.state-disabled:hover i,
        .smart-form .select.state-disabled:hover select,
        .smart-form .textarea.state-disabled:hover textarea,
        .smart-form .toggle.state-disabled:hover i {
            border-color: #e5e5e5 !important;
        }

    .smart-form .state-disabled.checkbox input + i:after,
    .smart-form .state-disabled.checkbox input:checked + i,
    .smart-form .state-disabled.radio input + i:after,
    .smart-form .state-disabled.radio input:checked + i,
    .smart-form .state-disabled.toggle input:checked + i {
        border-color: #e5e5e5 !important;
        color: #333 !important;
    }

    .smart-form .state-disabled.radio input + i:after {
        background-color: #333;
    }

    .smart-form .message {
        display: none;
        color: #6fb679;
    }

        .smart-form .message i {
            display: block;
            margin: 0 auto 20px;
            width: 81px;
            height: 81px;
            border: 1px solid #6fb679;
            border-radius: 50%;
            font-size: 30px;
            line-height: 81px;
        }

    .smart-form.submited fieldset,
    .smart-form.submited footer {
        display: none;
    }

    .smart-form.submited .message {
        display: block;
        padding: 25px 30px;
        background: rgba(255, 255, 255, .9);
        font: 300 18px/27px 'Open Sans', Helvetica, Arial, sans-serif;
        text-align: center;
    }

    .smart-form .ui-widget-content .ui-spinner-input {
        margin: 0;
        border: 0;
        box-shadow: none !important;
        height: 29px;
    }

    .smart-form-modal {
        position: fixed;
        z-index: 1;
        display: none;
        width: 400px;
    }

    .smart-form-modal-overlay {
        position: fixed;
        top: 0;
        left: 0;
        display: none;
        width: 100%;
        height: 100%;
        background: rgba(0, 0, 0, .7);
    }
</style>
<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePnl1" runat="server">
    <ProgressTemplate>
        <div class="col-sm-4"></div>
        <div class="col-sm-8 text-center" style="margin-bottom: 15px">

            <asp:Image ID="imgLoad" runat="server" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

<asp:UpdatePanel runat="server" ID="UpdatePnl1" UpdateMode="Conditional" ValidateRequestMode="Enabled">
    <ContentTemplate>


        <div style="text-align: right; margin-bottom: 15px" class="row">
            <div class="col-sm-12">
                <asp:Label CssClass="  form-control" Visible="false" ID="lblMessage" runat="server"></asp:Label>
            </div>

        </div>
        <div class="smart-form client-form">
            <header>
                ثبت نام در سامانه
            </header>

            <fieldset>

                     <section>
                    <label class="label">تلفن همراه</label>
                    <label class="input">
                        <i class="icon-append fa fa-mobile"></i>
                        <asp:TextBox ID="txtUsername" CssClass="validate[required,custom[phone],minSize[11],maxSize[11]] form-control" runat="server"></asp:TextBox>
                        <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i>لطفا تلفن همراه خود را وارد نمائید</b></label>
                </section>

                <section>
                    <label class="label">رمز عبور</label>
                    <label class="input">
                        <i class="icon-append fa fa-lock"></i>
                        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="validate[required] form-control" runat="server"></asp:TextBox>
                        <b class="tooltip tooltip-top-right"><i class="fa fa-lock txt-color-teal"></i>لطفا رمز عبور خود را وارد نمائید</b>
                    </label>

                    <label class="label">تکرار رمز عبور</label>
                    <label class="input">
                        <i class="icon-append fa fa-lock"></i>
                        <asp:TextBox ID="txtRePassword" TextMode="Password" CssClass="validate[required] form-control" runat="server"></asp:TextBox>
                        <b class="tooltip tooltip-top-right"><i class="fa fa-lock txt-color-teal"></i>لطفا رمز عبور خود را تکرار نمائید</b>
                    </label>
                </section>

                    <section>
                    <label class="label">ایمیل</label>
                    <label class="input">
                        <i class="icon-append fa fa-user"></i>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i>لطفا نام کاربری یا ایمیل خود را وارد نمائید</b></label>
                </section>

                <section>
                    <telerik:radcaptcha ID="captcha" runat="server" CaptchaTextBoxLabel="مقادیر روبرو را تایپ نمایید" ErrorMessage="کد کپچا را به صورت صحیح وارد نمایید" ValidationGroup="aut" ProtectionMode="Captcha">
                        <CaptchaImage FontWarp="High" ImageCssClass="captcha-image" TextChars="LettersAndNumbers" />
                        <TextBoxLabelDecoration />
                    </telerik:RadCaptcha>
                </section>
                <section>
                    <label class="checkbox">
                        <asp:CheckBox ID="chkRemember" runat="server" />
                        <i></i>مرا به یاد آور</label>
                </section>
            </fieldset>
            <footer>

                 <uc1:loadmoroorgarancontrols ID="load" runat="server" LoadValidationScripts="true"  LoadValidationStyle="true"></uc1:loadmoroorgarancontrols>
                <uc1:moroorgaranbutton ID="bt" runat="server" ValidateionType="validate" Width="45%" OnClick="btnSignUp_Click" CssClass="btn  btn-lg btn-block mt-15" Text="ثبت نام" />

                
                <asp:Button ID="btnCancel" Width="45%" OnClick="btnCancel_Click" CssClass="btn btn-danger" ValidateRequestMode="Enabled" CausesValidation="true" ValidationGroup="aut" runat="server" Text="انصراف" />

                 <div class="col-sm-12 text-center">

                   <!--  <a target="_blank" name="سیستم های اطلاعاتی | تلفن های هوشمند | وب سایت | نرم افزارهای اندروید" href="http://moroorgaran.com">شرکت مرورگران نوآوری توسعه  </a>
                     -->
                </div> 
            </footer>
        </div>
        <!-- <h5 class="text-center">ما را دنبال نمایید</h5>

        <ul class="list-inline text-center">
            <li>
                <a href="https://www.instagram.com/moroorgaran/" class="btn btn-primary btn-circle"><i class="fa fa-instagram"></i></a>
            </li>

            <li>
                <a href="https://www.linkedin.com/in/moroorgaran/" class="btn btn-warning btn-circle"><i class="fa fa-linkedin"></i></a>
            </li>
        </ul>
           -->

    </ContentTemplate>
</asp:UpdatePanel>
