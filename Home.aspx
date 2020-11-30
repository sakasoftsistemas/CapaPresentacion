<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CapaPresentacion.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .main-content {
            padding: 0px;
            margin: 0px;
            margin-left: 170px;
            text-align: center;
        }

        .slider {
            width: 95%;
            margin: auto;
            overflow: hidden;
            height: 100%;
        }

            .slider ul {
                display: flex;
                padding: 0;
                width: 400%;
                animation: cambio 20s infinite;
                animation-direction: alternate;
                animation-timing-function: ease-in;
            }

        .slider {
            width: 100%;
            list-style: none;
        }

            .slider img {
                width: 100%;
            }

        @keyframes cambio {
            0% {
                margin-left: 0;
            }

            20% {
                margin-left: 0;
            }

            25% {
                margin-left: -100%;
            }

            45% {
                margin-left: -100%;
            }

            50% {
                margin-left: -200%;
            }

            70% {
                margin-left: -200%;
            }

            75% {
                margin-left: -300%;
            }

            100% {
                margin-left: -300%;
            }
        }
        body{
            background:#000000;
        }
    </style>

    <div class="main-content">
        <div class="slider">
            <ul>
                <li>
                    <img src="publicidad/img1.jpg" style="height: 100%; text-align: center;margin:auto;" /></li>
                <li>
                    <img src="publicidad/img2.jpg" style="height: 100%; text-align: center;margin:auto;" /></li>
                <li>
                    <img src="publicidad/img3.jpg" style="height: 100%; text-align: center;margin:auto;" /></li>
                <li>
                    <img src="publicidad/img4.jpg" style="height: 100%; text-align: center; margin:auto;" /></li>
                <li>
                    <img src="publicidad/img5.jpg" style="height: 100%; text-align: center;margin:auto;" /></li>
                <li>
                    <img src="publicidad/img6.jpg" style="height: 100%; text-align: center;margin:auto;" /></li>
            </ul>
        </div>
    </div>
</asp:Content>
