# PawnshopSaga
2022 Capstone Design Project

# 과제 개요
수학 교육용 기능성 게임입니다. 타겟 유저층은 고등학생으로, 범위는 수학 교과목 중 ‘확률과 통계‘에 한정되어 있습니다. 기존 사례 분석 결과 문제 출제 과정의 개연성이 부족하다는 점과 저학년에 한정되었다는 점을 개선하였습니다. 이 개연성을 개선하기 위해 전당포를 운행하는 게임에 수학 문제를 도입합니다. 사들인 아이템을 감정하는 과정에서 수학문제를 제시하여 개연성을 챙기고, 사용자의 몰입을 유지할 것입니다.

# 과제수행 결과
![1](https://user-images.githubusercontent.com/65304950/174278060-fbec4e0c-95ff-4e77-817f-90c3ed4c9dec.png)
<br>
*타이틀 화면입니다. Start 버튼을 통해 게임을 시작합니다.
<br>
![2](https://user-images.githubusercontent.com/65304950/174278067-79f692ba-c4e3-40c6-bc9a-aba2c4c7634c.png)
<br>
*메인 화면입니다. 찾아온 손님이 아이템을 팔기 위해 가격을 제시합니다. 우측 패널에서 아이템이 가격과 이름을 확인할 수 있습니다. 구매한 아이템은 우측 상단 가방 아이콘을 눌러 확인할 수 있습니다. 좌측 상단 메뉴 버튼을 눌러 게임을 종료할 수 있고, 달러 버튼을 눌러 상점을 열 수 있고, 트로피 버튼을 눌러 여태까지 얻은 점수를 확인할 수 있습니다. 좌측 하단 help 버튼을 눌러 아이템을 감정하는 데 필요한 수학 개념을 배울 수 있습니다.
<br>
![3](https://user-images.githubusercontent.com/65304950/174278070-d3ce5e15-d30c-4a41-af5f-0fcddfa5718e.png)
<br>
*돋보기 버튼을 누르면 진입하는 감정화면입니다. 문제를 푸는데 성공하면 제대로 된 감정가가 매겨지며 아이템의 값어치가 비싸집니다. 문제를 푸는데 실패하면 감정에도 실패하며 값어치가 오히려 구입했을 때 보다 떨어집니다. 아이템 정보 UI에서 RE 버튼을 누르면 ‘re-examine scroll’ 하나를 소모하여 감정되기 전 상태로 되돌릴 수 있습니다.
<br>
![4](https://user-images.githubusercontent.com/65304950/174278074-a9c742e2-a48f-4540-ad06-f21b9af7304c.png)
<br>
*가방 화면입니다. 구매한 아이템이 장에 전시되어 있습니다. 구매한 아이템을 누르면 우측과 같이 아이템 정보 UI가 나타납니다. 아이템은 5개의 attribute가 있고, 각각의 attribute는 돋보기 버튼을 눌러 감정 가능합니다.
<br>
![5](https://user-images.githubusercontent.com/65304950/174278076-77d9b37c-28a4-45c9-86ba-cfe7e1232e04.png)
<br>
*help 버튼을 눌러 감정에 필요한 수학 개념을 배울 수 있습니다.
<br>
![6](https://user-images.githubusercontent.com/65304950/174278078-d4e0059c-107c-4a53-8116-178e5435af16.png)
<br>
*감정 방법들을 배울 수 있는 UI에서 배울 방법을 선택하면 감정 방법을 확대하여 보여줍니다. 해당 이미지는 material 감정 방법을 보여주고 있습니다.
<br>
![7](https://user-images.githubusercontent.com/65304950/174278080-ce074acf-4b97-493f-b48c-cc207b6948ff.png)
<br>
*상점 UI입니다. 게임 시작 시 material 감정 방법만이 열려있고, 아이템을 많이 팔아 얻을 수 있는 구독자 포인트로 새로운 감정 방법을 해금할 수 있습니다. Re-Examine-Scroll도 구매 가능한데 이것으로 잘못 감정한 아이템의 감정상태를 초기화할 수 있습니다.
<br>
![8](https://user-images.githubusercontent.com/65304950/174278081-7dceeea1-aa7e-4b75-9598-4bbc5e86d57a.png)
<br>
*트로피 버튼을 눌러 현재 점수를 확인하는 UI를 띄울 수 있습니다. 누적 판매액이 기록되며 많으면 많을수록 더 높은 등급을 부여받습니다.
<br>


# 학습자료 출처
[도곡동 막샘](https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=mathfreedom&logNo=221451091630)
