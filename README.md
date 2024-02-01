 # EvenIGamethon

## 주의사항
1. Push 이전에 항상 **pull** 할것 있는지 확인하기
2. **Scene 작업** 전에는 항상 Scene 관리자에게 물어보고 작업하기
3. 작업 내용의 **주석**은 최대한 상세히
4. **상속 구조로 이루어진 스크립트**는 기존의 변수명 수정은 최대한 삼가고 불가피하게 작업을 해야하는 경우는 팀원들에게 미리 알리고 주석을 상세히 달기
5. 개발 버전 업데이트 규칙
   - 최신 업데이트를 **최상단**에 배치

|V.1.0.0  | 1             | 0            |  0           | JS      | 2024-01-08 |
|:-------:|:-------------:|:------------:|:------------:|:-------:|:-------:|
|   의미  | 개발일정 페이즈 | 씬수정       | 스크립트 작업 |작업자    |  날짜  |

6. 개발 일정 페이즈  

|구간   |    Phase1    |     Phase2   |      Phase3   |     Phase4    |
|:----:|:------------:|:------------:|:-------------:|:-------------:|
|기간| 01.08 ~ 01.26 | 01.27 ~ 02.02 | 02.03 ~ 02.09 | 02.10 ~ 02.23 |
|개요| 게임 구현 | 서버 구현(구글플레이 제외) | 서버 구현(구글플레이 포함) | 최종 QA, 버그 수정, 추가적인 시스템 구현 및 개발 최적화| 
---
## V.2.1.6 - JS 2024-01-31
- 사운드
  - 사운드 클립 설정
    - Force To Mono : 모노 채널 타입으로 변경
    - SFX
      - Decompressed On Load
      - 압축품질 40으로 셋팅
    - BGM
      - Compressed In Memory
      - Compression Format : Vorbis
    - <AudioSource\>.dopplerLevel , <AudioSource\>.reverbZoneMix 각각 0으로 초기화
    - 오프닝(배경음) Load In Backgroudn Check : 비동기 방식으로 사운드 설정
  
- BGM 사운드 적용
  - Opening, Shop, Battle01

- SFX 사운드 적용
  - UI PopUpWindows

---
## V.2.1.5 - SM 2024-01-31
- 닉네임 변경 기능 추가
<p align="center">
<img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/387412bc-9cc7-448d-9a67-3a4eb3f23c6c" width = "180" height = "360">
</p>  

- 사운드 삽입
  - 메인 모든 공격 사운드
  - 서브 모든 공격 사운드
  - 보스 경고 사운드
  - 서브 타워 소환 사운드
  - 몬스터 사망 사운드
  - 몬스터 공격 사운드
  - 승리, 패배 사운드
    - 패배 로직 수정 필요 -> 시간 정지하면 소리도 안나올 수도
  - 성벽 부서지는 사운드
    - 성벽 부서지는거 로직 수정 필요 -> 현재는 Update라 소리가 계속나옴
  - 몬스터 걸어가는 소리 -> 넣으면 안될듯
- 뒤끝 유저 게임 정보 테이블 추가
  - 테이블 정보 불러오는 로직 구현
  - 아직 적용은 되지 않고 틀만 만들어 두었음
- 메인 캐릭터 레벨업에 따른 능력치 증가 틀 구현
  - 서버 테이블 연동시 정상 작동
---
## V.2.1.4 - JS 2024-01-30

- 레터 박스
  - 게임화면에 해상도를 Main Camera 기준 1080 * 1920으로 고정
    - 카메라 depth -2로 지정하여 UI 보다 아래 쪽에 그려지게 고정
    - 이에 따라 grid background와 tilemap 각각 -3, -2로 변경
  - UI 해상도 Camera 기준 1080 * 1920 으로 고정
    - Render mode : Screen Space - Camera로 설정
    - depth -1로 지정
  - 위 설정만 진행하였을 시, 에디터 상에서는 적용되나 안드로이드 빌드 후, 레터박스 적용이 안되는 현상 발견
  - [Build Settings] - [Player Settings] - 안드로이드 탭의 Resolution Scaling 의 Resolution Scaling Mode를 LetterBoxed로 설정 이후 문제 해결 (올바른 해결책인지는 모름...)

<p align="center">
<img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/07ac9b63-407d-43c4-96ad-ae7b34bb03ee" width = "130" height = "250">
</p>

- UI
  - Speed Toggle 버튼 이미지
    - 이미지 아래 자식 이미지 생성해서 IsGameSpeedIncreased 변수의 불린 값에 의해 자식 오브젝트 SetActive false/true 하는 형식으로 구현

<p align="center">
<img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/c340ba13-93b1-4888-b0af-0967b476deec" width = "240" height = "60">
</p>
  
   - ShopUI
     - 제작 완료
     - 스크롤 뷰 UI 사용

<p align="center">
<img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/75301e04-a2c0-4293-adef-2574af72a31e" width = "240" height = "280">
</p>

- 버그 수정
  - 2배속으로 플레이하다가 스킬카드 선택하고 다시 배속돌아옴(유지안됨) => 해결 완 속도 유지
  - 스킬이미지 안쪽의 Lv 텍스트 흰색으로 변경됨 

---

## V.2.1.3 - SM 2024-01-30
- AndroidManifest.xml 수정
    - 플레이스토어 정책에 맞게 광고 허용
- 프로필 창에서 현재 닉네임 뜨도록 동기화
    - 내일 닉네임 변경 기능 추가 예정
---
## V.2.1.2 - SM 2024-01-29
- 전투
  - 루모스 이속 감소효과 적용되지 않던 버그 수정
  - 밸런스 패치 적용
  - 봄바르다가 날아가는 도중에 타겟이 바뀌던 버그 수정
  - 봄바르다 애니메이션 최적화(has exit time 관련)
  - 포찌 애니메이션 최적화(has exit time 관련)
- 서버
  - 구글 플레이 앱 게시(내부 테스트)
<p align="center"> 
<img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/173af56d-0ab6-43c4-9252-67ca3d605c0d" width = "260" height = "420">
</p>
  - 구글플레이스토어 인앱 결제 키 프로젝트와 연동
  - 구글플레이 게임 서비스 로그인 성공
  - 구글플레이, 뒤끝 서버 연동하여 자동로그인 진행
<p align="center">
<img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/f69a3285-aaa0-4d44-8da2-741ae2b4cf8f" width = "260" height = "420">
</p>
    - 뒤끝 DB에 유저 정보 추가되는 것 확인
<p align="center">
<img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/20e652bc-f891-4f65-9968-267b3c66a720" width = "1200" height = "100">
</p>
  
---
## V.2.1.1 - SM 2024-01-28
- 전투씬 수정 내용
    - 데미지 팝업이 int형으로만 뜨도록 변경
    - Lumos 폭발 추가가 작동하지 않던 버그 수정
    - 봄바르다 해금시, 매직볼의 콜라이더가 꺼지던 버그 수정
    - 최종 보스 비주얼 업데이트
- 서버 작업
    - 뒤끝 서버에 연동함
    - 로그인 임시적으로 구현
        - 회원가입
        - 로그인
        - 아이디 찾기
        - 비밀번호 찾기
    - GPC 연동 끝나면 구글플레이 로그인으로 변경 예정
### 현재 버전으로 빌드 팀원들에게 배포함
---
## V.1.2.15 - JS 2024-01-28
- 버그 수정
  - 서브햄찌 설치창 열린채로 레벨업 됬을때, 아무 버튼 안눌리는 버그 (수정완)
  - 카드 레벨업 시 열려있는 모든 팝업을 닫고, 카드를 선택하는 행위 말고는 어떠한 행동도 하지 못하도록 코드 변경
  - 업그레이드 UI 팝업창이 켜져 있을때, 서브햄찌 건설 UI를 팝업하면 버튼이 먹통이되는 버그 (수정완)
- 서브 햄찌
  - 제거 버튼 생성 및 로직 구현
- 인게임 재화 (해바라기씨)
  - 게임매니저에서 seed 변수를 사용해서 UI 구현
- UI
  - Card Level 텍스트 색깔 흰색으로 변경

---
## V.1.2.14 - SM 2024-01-28
- 흑찌 이슈 해결
    - 최종적으로 메인 게임플레이에 관한 구현은 모두 종료
- 서버 작업 시작을 위한 뒤끝 패키지 추가
- *페이즈 2로 전환*
---
## V.1.2.13 - SM 2024-01-27
- 게임이 종료되어도 없는 다음 웨이브가 진행되던 버그 수정
- 내일부터 서버 작업 시작
- 몬스터 스폰시 발밑에 그림자가 생기도록 구현
- 흑찌 제외 전부 구현됨
- 보더라인 관련 버그 -> 그냥 총알들이 생성되자마자 비활성화됨
    - 보더라인 일단 없애놨음  
#### 이슈
- 흑찌 공격 데미지 안들어감
---
## V.1.2.12 - JS 2024-01-27
- 에너지, 게임 재화
    - 설명란 한글 내용추가
    - 숫자 크기 조정 (천의 자리까지는 표현가능)
  - 프로필
    - 이미지 크기 조절
    - 캐릭터 이름 집어 넣는 로직 미구현 => 서버 작업 전에 진행 예정
    - 레벨업 버튼
      - 소모 재화 표시 UI 구현완료
      - 레벨업에 실패했을 때 뜨는 하단 문구 구현 완료
      - 전체 레벨로직 현재 미구현 => 서버 작업 전에 진행 예정
  - 전투
    - 현재 Chapter 창에서 Stage를 누르고 Chapter-Stage가 보이는 상태에서 Start 버튼을 누르는 방식인데,  그냥 이렇게 쓰는 것은 어떤지 의견 묻고 싶음 (초기 개발에 이 구조로 짜놓음)
    - 스테이지 클리어 진행도 저장 현재 미구현
    - 챕터 이동시 흑백이 현재 구현에러가 나는 상태 (원인이 뭔지 모르겠음) => 가능은 하겠지만 디버깅할 시간이 하루 정도는 필요 (FGT 기간에 진행 할 예정)
    - 스테이지 시작 시 스테이지 시작 UI 팝업창 구현완
    - 스토리 탭 구현 완료 (기능 미구현)
  - 카드
    - (추가) 카드 선택창 UI 한글 업데이트

*미구현*  
> 도감, 상점
---
## V.1.2.11 - JS 2024-01-26
- 카드
  - 구현 불가 카드에 대한 조정
  - 카드 조정에 따른 카드 등장 여부 수정
- 서브캐릭터
  - TowerUI 클릭 중복 버그 수정
---
## V.1.2.10 - SM 2024-01-26
- 레벨 20달성시 더이상 경험치 오르지 않도록 조정
	- 승리로직 정상 작동 확인
- 준보스 몬스터 3스테이지 이전에는 출현하지 않도록 조정
- 서브햄찌 설치, 데이터 파싱, 오브젝트 풀링 로직 완료
	- 이제 동작 구현, 애니메이션 삽입 하면 됨
- 관통 추가를 위한 작업
	- 매직볼, 피네스타 유도에서 직사로 변경
- 루모스, 매직볼 폭발속성 추가 가능하도록 변경
- 직사 스킬 추가로 인한 리소스 낭비 방지 장치
        - 화면 밖으로 총알이 나가면 비활성화시켜서 재활용 가능한 상태로 만듦  
*내일까지 서브햄찌 모든 동작 완료시킬것 -> 페이즈 2로 넘어가야 함*
---
## V.1.2.9 - JS 2024-01-25
- 서브 햄찌
  - SpawnPoint 2개의 지점 RuleTile로 지정 (Tag "Tile"을 가짐)
  - 마우스 RayCast가 Tag와 일치할 때, TowerUI(타워 설치용 UI)를 불러온다
  - PopUpWindow 스크립트를 부착하여 PopUpManager의 구조를 사용하여 TowerUI 프리팹을 불러오고, 각각 버튼을 눌렀을 때, 설치형 햄찌를 Instantiate 한다
  - 프리팹 Tower01 (for Test) 게임 씬 하이어라키에 생성됨 : 설치형 햄찌 인스턴스

- TowerSpawner
> 이는 추후에 ObjectPool을 이용한 구조로 변경 할 수도 있다 (참고용)

- ObjectDetector
  - 서브햄찌와 설치가 가능한 지점을 확인하기 위한 디텍터 스크립트

- Tile
  - 같은 타일에 재생성을 막는 스크립트

- TowerUI
  - 타워 설치 가능한 지점을 눌렀을 때, 생성되는 타워 설치 UI

<p align="center"> 
  <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/6c87cab6-dc9f-440a-9854-3f2b0a106060" width = "130" height = "210">
  <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/ee3c8fee-3c85-4159-97a9-3b38860eb6fd" width = "130" height = "210">
</p> 

- UI
  - ScoreUI
    - Bg 교체
<p align="center"> 
  <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/2b26493a-0510-48aa-b051-09fb7010ebcb" width = "130" height = "210">
</p> 

  - CardUI
    - 스크롤 이미지 수정완료
    - CardUI 전체 크기 1.3배 확대
    - 배경 이미지 삭제 (전체 패널이 투명하게 보임)
<p align="center"> 
  <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/3e0cda15-1853-40d5-bbcb-9755d38da6a7" width = "130" height = "210">
</p> 

---
## V.1.2.8 - SM 2024-01-25
- 피네스타 구현
- 기본 공격 비주얼 업데이트
- 루모스 구현
- 모멘스토 구현
	- 넉백로직 수정 필요할수도
		- 현재 넉백은 반대편으로 속력을 주는 방식
		- 이 방식으로는, 맞는 대상의 속력에 따라 넉백 거리가 달라짐
- 아구아멘티 구현
- **모든 스킬 구현 완료**
- 챕터별 맵 적용
- 데미지 팝업이 이전 데미지의 숫자가 뜨던 버그 수정
---
## V.1.2.7 - JS 2024-01-24
- Sound
  - 사운드 매니저 시스템 구축 완료
  - Intro 씬에서 시작할 때, AudioManager를 싱글톤으로 생성
  - BGM Player는 단일 AudioSource, SFX Players는 복수의 AudioSource로 구성.
  - Inspector 창에서 Sound Engineer가 작업하기 쉽게끔 하나의 AudioManager 하나의 오브젝트에서 조정이 가능하게 끔 구현

<p align="center"> 
  <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/f33b4694-7fb8-4966-9dff-ea98882deab6" width = "260" height = "280">
</p> 

  - PopupManager를 이용해서 PopUpWindows를 나타내는 방향으로 PopUpSystem을 구현 하였기 떄문에 SoundSettingUI가 열릴 때, 게임 상의 Sound를 받아오고, 새로 생성된 Slider에 AddListener를 이용해 함수를 연결해주는 작업 완료  
---
## V.1.2.6 - SM 2024-01-24
- 총알 로직 전면 수정
	- 콜라이더 배제
		- 콜라이더가 정상적으로 작동하지 않는 이슈가 지속적으로 발생
		- 콜라이더를 배제하기로 했음
	- Transform만으로 판정하도록 로직 수정
---
## V.1.2.5 - JS 2024-01-23
- UI
   - 메인 Text : 학교안심 여행 R.ttf 로 결정
   - Text(Legacy)에서 TextMeshPro로 UGUI 전부 변경
- SoundManager
   - 사운드 매니저 시스템 구축 (수정 필요)
   - PopUpUI에 있는 OnClickEvent를 씬에 존재하는 SoundSetting 또는 SoundManager에 어떻게 전달할 것인지에 대한 연구 필요
---

## V.1.2.4 - SM 2024-01-23
- 보스전 워닝 만들기 -> 완료
- 엑서니아 구현
    - 기즈모상으론 맞은게 확실한데, 데미지가 안들어감
    - 범위형 스킬들 전부 해당
    - 데미지가 들어갔다가 안들어갔다가 자기 맘대로임
- 봄바르다 비주얼 업데이트
- 콜라이더 관련 이슈 내일 질문할
---
## V.1.2.3 - JS 2024-01-22
- Battle_Proto_Test
   - 배틀씬을 테스트하기 위한 씬 복제
- CardData / 스크립터블 오브젝트
   - 카드 잠금 여부 확인하는 불 값 추가
   - 폭발 스킬 해금여부 확인하는 불 값 추가
   - 투과 스킬 해금여부 확인하는 불 값 추가
   - 플레이 모드에서 OnEnable시 해당 불 값 초기화
- LevelUp
   - 카드 3장 뽑고 중복체크, 유효한 카드 체크한 후 조건에 맞지 않으면 다시 뽑는 로직 설계 및 추가
   - 더블 업 카드 관련해서 시간 복잡도 증가 때문에 우선 미적용 (해결 필요)
- Card
   - 각 카드에 대한 로직 작성 (더블 업 포함)
- Wall
   - 게임 끝났을 시 게임 시간 멈추는 로직 구현
- UI
   - Card Description overflow에서 Wrap, Truncate 적용 

---
## V.1.2.2 - SM 2024-01-21
- 1차 빌드 진행
- 경험치 요구량 적용
- 경험치 획득량 적용
- 벽 이미지 적용
- 고정 프레임 적용
---
## V.1.1.10 - SM 2024-01-20
- 루모스 구현
    - 사거리 내의 적들 중 무작위로 번개가 떨어짐
    - 번개를 맞으면 일정 시간 마비 효과 적용
    - 마비 적용중에는 노란빛이 돌도록 수정
- 피네스타 구현
- 모멘스토 구현
    - 중앙의 포인트들 중 하나에서 랜덤 생성 -> 기획서대로
    - 맞는 적들을 넉백
- 여러 스킬들이 동시에 활성화 되어 있을 때 자잘한 버그 수정
    - 투사체가 날아가는 도중에 타겟이 죽는 경우 처리
- 넉백을 위해 몬스터의 이동 rb.movement에서 rb.velocity로 변경, 그에 따라 원래 속력에서 * 50하여 간극을 줄였음
---
## V.1.2.1 - JS 2024-01-20
- 승리 로직 구현
  - VictoryUI
    - No : GoToHome Button
    - Yes : GoToNextStage 함수 구현 : 테스트 진행은 못해봄 (버그 있을 수 있다)
- 패배 로직 구현
  - GameOverUI
    - No : GoToHome Button
    - Yes : Retry Button
- Spwaner Start함수 변경
  - Battle_Proto 에서도 Run 되게 코드 수정
- 카드 뽑기 로직
    - AchiveManager와 PlayerPrefs를 활용하여 각각의 Card를 SetActive 하는 방법으로 구현해 봄 -> 실패
    - Card가 모두 Active 되어 있는 상태에서 카드 뽑기가 안되게 끔 하는 방법으로 접근 필요 (Boolean...?) 


---
## V.1.2.0 - JS 2024-01-19
- SceneManager 구축으로 인한 개발 버전 업데이트
- Image Upload
  - 시드 (해바라기 씨)
  - 로고, 배경이미지
  - 타이머 (인게임 타이머 이미지) 

- Lobby
  - 로비 씬 UI 작업 완료
  - <p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/114fa4ac-c6cc-415b-a588-f2e8f5ec941c" width = "150" height = "250">   

  - 배경은 Grid로 작업할 예정

- PopUpManager
  - PopUpManager 시스템 구축
    - PopUpManger.cs : 스태틱 프로퍼티로 프리팹으로 생성된 PopUp들을 [Canvas] - [PopUps] 아래 생성하게 하고 차례로 Close 할 수 있게 구현
    - PopUpWindow.cs : Stack 기반으로 PopUpWindow가 열림
    - PopUpNames.cs : PopUp 이름을 관리하는 MonoBehaviour를 상속 받지않는 단일 클래스. PopUpManager에서 생성 및 초기화를 함
    - PopUpHandler.cs : 각 버튼에 대한 동작함수(PopUp)를 정리

    > PopUpManager를 활용하여 직관적이고 가독성 높은 코드를 작성함.  

    > 구현 중에 유지보수하기 쉬운 코드로의 리팩터링을 해나가며 작업한 것이 큰 도움이 됨.  

  - Settings, ExplainStamina, ExplainCorn 작업 완료
     - <p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/0b02e72c-d263-40c1-8def-10e0434c1031" width = "150" height = "250"> 
     - <p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/a73f2a6c-9b98-4c5b-9233-d13f50a96ded" width = "150" height = "250"> 
     - <p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/9b9a437c-6a8d-4d45-8328-cdf15533eb56" width = "150" height = "250">
    
- DragPlayer
  - IPointerClickHandler 인터페이스 활용
    - 클릭시 Profile이 PopUp 되게 구현
    - 추가적으로 IDragHandler, IEndDragHandler를 활용한 Dragable Object도 활용 가능
    - 개발PM님과 미팅 완료하였고 추후 애니메이션 추가되면 활용 가능성 있음

- Scene
  - SceneManager 시스템 구축
    - SceneLoader를 싱글톤으로 구현
    - Loading 바 차는 것을 시각적으로 보여주기 위해 SmoothDamp 이용해서 Debug용 딜레이 추가
    - <p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/30c72f99-b5c0-4a18-ba49-1358908e604f" width = "150" height = "250">

- 해야할 일 :  AchieveManager
  - 해금 조건 달성 매니저 초기 세팅 완료
  - 이차원 배열안에 해금 카드들의 GameObject를 다 담아 놓고, 해금 카드를 선택했을 시 SetActive하는 방식으로 구현 예정 
  - 1차 프로토 타입 Build Test를 위해 UI 작업을 우선 진행하였고, 21일 이후에 다시 Card 뽑기 로직 작업 진행 예정

---
## V.1.1.9 - SM 2024-01-19
- 붐바르다 최종 구현
    - 최종 구동 확인 -> 범위 딜 정상 작동
    - 기획안 수정 -> 충돌시 데미지 입힌 후 폭발 추가 데미지 -> 폭탄을 던지듯이 그냥 폭발 데미지만
    - 관련 데이터 Xml에 추가
    - <p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/a5c3b1ff-9770-48d2-95a9-fc66f852f9a6" width = "130" height = "210">   
- 루모스 구현 준비
---

## V.1.1.8 - JS 2024-01-18
- LevelUp.cs 로직 구현
  - 공통 적용 부분 구현 완료
    - Damage, CoolTime 등
    - 해금 시스템 구현 필요...
- Lobby_Battle UI 구현 완료
  - Chapter, Stage 별 버튼 스크립트화 완료
  - StageSelect를 기준으로 chapter, stage spwaner에서 사용하고 있기 때문에, 다시 Lobby_Battle 씬이 로드 되어도 이전 정보 저장할 수 있게 코딩 완료
  - <p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/b94acab3-22ae-4f5c-8863-ccb5efe97a5b" width = "130" height = "210">   
---

## V.1.1.7 - SM 2024-01-18
- 챕터별 커지는 몬스터들 배율 적용
- 스킬 로직 준비
    - 확정난 이펙트로 매직볼, 봄바르다, 아구아멘티 애니메이션 작성
- 보스전시 특수효과
    - 각 챕터 스테이지 5, 웨이브 10에대한 예외처리
    - 빨간빛 깜빡거리는 특수효과 + 보스몹 스폰 함수 별도 마련 완료
- 누락된 몹 애니메이션 추가
    - 2-1~5
- 각 스킬 애니메이션 상속 구조 구현
- 봄바르다 -> 피격시 폭발 애니메이션 나오게 구현 -> 애니메이션 종료후 비활성화
    - 폭발 애니메이션시 데미지 들어가는 로직 추가 필요
- 몬스터 피격 OnTriggerEnter와 TakeHit 함수 분리 -> 스킬 구현에서 사용하기 위해서
- *봄바르다 관련 이슈*
    - 딜레이가 들어가면 데미지가 안들어가고, 딜레이를 없애면 데미지가 잘 들어가는 현상 -> 아직 해결 실패
---
## V.1.1.6 - JS 2024-01-18
- LevelUp.cs 로직 구현
  - 카드 3가지 뽑는 로직 구현
  - ScriptableObject 스킬별로 분류
      - 행은 열거형 Type으로, 열은 CardId로 구분

- 해야할 일
  - 해금 로직 구현
  - 폭발, 지속시간 증가 로직 구현 연동 필요 (구현이 되면)

---
## V.1.1.5 - SM 2024-01-17
- 스테이지별 몬스터 스탯 배율 적용
- 메인 햄찌 적용
- 각 스킬 틀 제작 
    - 실제 작동 로직은 아마 내일, 에셋 확정
- 몬스터 피격시 깜빡깜빡거리도록 시각 효과 추가
---
## V.1.1.4 - SM 2024-01-16
- 레벨 디자인 기획서대로 전부 Xml화
- 스테이지, 챕터 선택창 테스트용 제작
<p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/073021c1-fcc7-4eca-baf5-547a27572e1a" width = "200" height = "320">

- xml 불러와서 각 웨이브별 소환될 몬스터들을 저장
    - 저장 후 셔플, 섞인대로 소환
    - 프리팹 하나로 모든것을 통제하기 위한 코딩
- 몹, 플레이어, 웨이브 데이터 모두 삽입
    - 정상 작동
- 몬스터 피격시 데미지 팝업이 뜨도록 설정
<p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/88022886-73a0-4b7e-b4ff-23f68bd6c2a3" width = "200" height = "320">

##### 내일 할 일
- Idle 애니메이션 제작 후 벽에 도달시 Idle, Attack 둘만 나오도록
- 스킬별 폭발 등 로직 구현
- 메인햄찌 적용, 애니메이션 코드 구현
---
## V.1.1.3 - JS 2024-01-15
- Card.cs 추가 작업
  - Card UI 리팩토링
    - Card 스크립트에서 Player 스크립트 바로 참조해서, PlayerData의 배열에 접근하여 데미지를 증가 시키는 방식 - 구현 완료
      - 추가적으로 기본 공격으로 나가지 않는 2,3,4,5,6,7,8에 해당하는 스킬들을 해금하는 방법에 대해 수민님과 논의가 필요함
      - 데미지 증가, 관통, 쿨타임 감소는 적용이 간단 하므로 즉시 적용 가능.
      - 폭발 적용, 폭발 데미지 증가, 공격 범위 증가, 스킬 지속시간에 대한 구현 방법에 대한 논의 필요
    - 현재 구현 된 방식으로는 한 종류의 카드가 무한히 뜨게 할 수는 없으니 상한선 기획 필요

  - 창 컨트롤 완료
    - 레벨업 시 Card UI 뜨게 설정

  - 시간 컨트롤 완료
    - GameManager에 Stop(), Resume() 함수 만들어서 게임 시간에 접근할 수 있게 함수 추가

  - 랜덤 아이템 디자인
    - 미리 만들어 둔 스크립터블 오브젝트를 랜덤하게 뜨게 하는 로직 설계 필요
    - 해금이 우선이 되어야 하기 때문에 레벨은 살리는 방향으로 설계 할 예정

<p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/2dcddee9-2418-4ad1-b8a8-67dfa25db668" width = "350" height = "200">   

- StageClear UI
  - StageClearUI 제작 완료
  - Reward, Stage Clear 랭크, 애니메이션 제작 필요

<p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/f83016d8-0e6c-4831-a50d-8ba60cf75857" width = "150" height = "180">

- UI Font 변경
  - 현재 UI 폰트 한글 지원 안됨 : 변경 예정

- 특이사항
  - 파라미터 에러 발생 _unity_self
  - 간헐적으로 발생하는 것으로 확인되고, 유니티 버그 인 것 같기도... 유니티 재시작 시 안나는 것 확인했는 데, 지속적으로 나면 Issue Tracking 필요  

<p align ="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/60afc6fe-d8f7-4384-9dcb-6140e1860570" width = "350" height = "170">

---

## V.1.1.2 - JS 2024-01-14
- Card, CardData script 작성
  - [일반 몬스터] - [메인 캐릭터 스킬]에 해당 하는 부분
  - ScriptableObject를 이용해 스킬 종류에 따라 구분하고, 스킬 카드 종류에 따라 PlayerData의 값을 변화 시키는 로직으로 설계
    - PlayerData와 Card 스크립트 간의 연결을 어떻게 해야할 지 고민이 필요...
- UI Font 변경
  - ThaleahFat Legacy Font 사용
---

## V.1.1.1 - SM 2024-01-14
- 스킬에 따른 쿨타임 로직 개선
- 적 벽에 도달후 움직이는 버그 개선
- 스테이지별 몹 리젠 수 적용(기획서대로)
- 게임 승리 로직
    - 현재 스테이지에 나오는 총 몹의 수를 받아서, 몬스터가 죽을 때마다 --, 0이 되면 승리 로직 시작
- 확정된 에셋 애니메이션 제작
- 확정된 에셋 애니메이션 상속구조 생성, 몬스터에 적용
    - 내일 할 일 -> Idle 모션 만들기, 상속구조 수정
<p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/dc71ef49-5f08-4f8e-b83e-3ae3d69e813f" width = "200" height = "320">

---
## V.1.1.0 - JS 2024-01-12
- 해상도 변경
  - 1080 * 1920 (최종 확정)
  - 해상도 변경에 따른 UI 변경 작업 진행
- Battle_Proto Scene에 UI_Proto Scene 병합 작업 진행
  - 프로토 타입 개발을 위한 간단한 업무이기 때문에 한 씬에서 작업을 하는 것이 작업 속도 향상에 유리하다고 판단함  
   <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/105345909/18094dc4-7835-4124-b3a9-988baa6272b8" width = "200" height = "320">
  
- Exp, Level, Time Data 업데이트 동기화
  - Hp 동기화는 수민님과 코드리뷰 이후 명일 작성 예정
- 수진님 스킬 규칙 설명 기획서 확인
  - 개발 측면 피드백을 위해 2024-01-13 오후 시간대 미팅 예정

---
## V.1.0.4 - SM 2024-01-12
- 자동공격 로직 작성
- 스킬에 따른 다른 쿨타임 독자적으로 돌아가도록 작성
- 몬스터 Xml 데이터 파싱 적용
- 벽 체력 설정
	- 벽 피격 로직
---
## V.1.0.3 - SM 2024-01-11
#### Battle_Proto 씬 작업
- 총알 오브젝트 풀링
    - 몬스터의 오브젝트 풀링과 같은 방식으로 작동
- 플레이어 총알 발사 로직
    - ##### 오류 수정 사항
    - 발사 시 발사 방향으로 회전된 스프라이트가 나오도록 처리
    - 총알이 날아가는 도중에 적이 죽어버리는 경우 처리
    - 가장 가까운 적을 찾는 함수가 비활성화된 객체들까지 포함해서 계산하는 오류 처리
- 몬스터 피격, 사망 로직
    - 몬스터 피격시 데미지를 받고, 사망하도록(SetActice(false))
- XML 파싱 틀 제작
    - 현재는 메인 캐릭터의 데이터가 파싱되도록 처리됨
    - 추후 몬스터쪽에도 적용할 예정
<p align="center"> <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/7fae7317-bc98-45bc-95ce-b5580492e40a" width = "180" height = "320">
  
---
## V.1.0.2 - JS 2024-01-11
- 싱글톤 제네릭 업데이트
  - 재생산성을 높이기 위해 제네릭 타입으로 싱글톤 스크립트 작성완료, 게임 매니저에 적용
- UI 작업
  - UIManager 스크립트 작성
    - GameManager 호출 이후 UIManager를 생성하고, GameManager와 커플링 없이 UI 업무는 UIManager에서 독립적으로 실행할 수 있게 구현 예정
  - CardUI
    - 특정 조건(레벨업)이 되었을 때, CardUI가 오픈되고 게임은 일시 정지된다.
    - 세가지 선택지 중에 하나를 선택하였을 때, 해당 카드의 효과를 스테이지 상에 즉각 업데이트하며(미구현) 게임 플레이가 재개된다.
    - Card 선택 메소드는 따로 로직 작성할 수 있게 스크립트 분할 작업
  - GameSpeedUI
    - 기본 배속, 1.5배속 버튼 형식으로 추가, 후에 Asset 정해지면 이미지 토글 형식으로 대체 예정
  - PauseUI
    - Home
    - Resume
    - Retry
---
## V.1.0.1 - SM 2024-01-10
#### Battle_Proto 씬 작업
- 적 오브젝트 풀링 틀 작성
    - 적 객체가 사망 시 Destroy()가 아닌 SetActive(false) 시켜서 씬에 남아있게 함
    - 다음 적이 생성될 때 현재 비활성화된 객체가 있는 경우 해당 객체를 재활용해서 생성
    - 없는 경우에는 새로 생성
    - 적은 프리팹 하나로 구현
        - RuntimeAnimatorController만 바꾸면 외형도 바뀌게 작업
        - 몬스터 능력치는 SpawnData로 삽입됨 -> 추후 Xml로 삽입하도록 변경 예정
    - PoolManager에는 위에서 적은 프리팹 정보가 들어있음
    - Spawner에는 SpawnData 배열로 능력치가 저장되어있음
    - 해당 정보들을 불러와서 몬스터를 생성하는 방식
- 적 움직임 작성
    - 적 움직임은 Y축으로 내려오는 움직임만 필요하므로 해당 부분 작성
- 각 웨이브 시간마다 다음 웨이브가 몰려오도록 작성
<p align="center"> <img src = "https://github.com/Jinlee0206/Jinlee0206.github.io/assets/105345909/ae6f4c1b-b2de-4e65-a4fb-89fe67223a1a" width = "180" height = "320">
  
---
## V.1.0.0 - JS 2024-01-10
- 전투 기획 초안
  <details>
  <summary> 접기/펼치기 </summary>  
  <img src = "https://github.com/Jinlee0206/EvenIGamethon/assets/109404269/f2f72556-ab26-4a0d-860c-51dd179601a8" width = "420" height = "930">
 </details>

- 해상도 조절  
  - 9 * 16 모바일 비율 임시 설정 (택)
  - 9 * 19 플립 같은 종횡비가 큰 비율

- UI 작업
  - Title UI
    - 임시 타이틀로 간단하게 배경과 이미지, 타이틀, 그리고 시작 문구로 간단 제장  
   <img src = "https://github.com/Jinlee0206/Jinlee0206.github.io/assets/105345909/a1f63735-e03f-4134-b89e-c71f951d7c5e" width = "180" height = "320">

  - Stage UI
    - ScoreUI
      - 획득 점수 / 플레이 속도 조절 버튼 (임시)
        - 점수는 Int 형으로 Text 받는 식으로 GameManager 구축 후 추후 연동
        - 플레이 속도 조절은 버튼으로 구현할 예정 => 버튼을 누를 때마다 이미지 변경되게 구현 예정 
      - Wave  
        - 현재 웨이브와 해당 스테이지 총 웨이브 표기
      - Timer
        - 해당 스테이지 시작부터 타이머 쭉 흘러가게 설정
      - Exp Bar
        - 슬라이더로 제작
        - 왼쪽에서 오른쪽으로 채워지는 형식으로 구현
        - 100% 채워질 시 카드 오픈 UI 뜨게 구현 예정
        - 현재 레벨을 알 수 있게 레벨 표시도 진행하게 기획 수정 요청 필요
    - DefenseUI
      - SpawnPoint
        - 중앙에 위치한 스폰 포인트는 기본 햄찌가 소환될 곳 (default)
        - 양 옆에 서브 햄찌가 소환될 공간을 미리 만들어두고 클릭해서 건설할 수 있는 타워 디펜스 형식의 구현 예정  
       
    - AttackUI
      - 해금되는 기본 공격 스킬 탭
      - 쿨타임이 돌면 자동으로 공격이 실행되고 쿨타임 아이콘 UI 보여질 예정
     <p align="center"> <img src = "https://github.com/Jinlee0206/Jinlee0206.github.io/assets/105345909/87342756-c30a-4d58-b753-39cf4a6e4f3e" width = "40" height = "40">

    - 최종 결과   
    <p align="center"> <img src = "https://github.com/Jinlee0206/Jinlee0206.github.io/assets/105345909/6caae26b-e6ab-4e0d-a905-7df65e6b70b9" width = "180" height = "320">
    
---

### V.0.0.0 - JS 2024-01-08
- 개발 초기 셋업
  - Unity Version matching : V22.3.4.f1  
  - Asset Serialization Mode : Force Text  
  - Git Repository set up : 개인 레포지토리에 개설, public으로 사용 예정  
  - Git LFS installed and checked -> success  
  - Test Project 생성  
    - 개인 Layout 생성

- Git, Github 비개발자 직군 간단 세미나

- Asset Searching
  - 상위 기획 자료 미팅 (2024.01.08 22:00 예정) 이후 방향성 확인 이후 어울릴 만한 Asset search
   
- 공동 작업용 변수명 통일 기준 확립
  - [C# 변수 명명법](https://jinlee0206.github.io/develop/Naming.html)
  - 폴더 분류 기준 확립

- 개발자 간 개발 작업 분업화 미팅
  - 대주제 : 프로토 타입단계에서 Scene 담당, 수학 로직, 이펙트, UI, ... , etc.
